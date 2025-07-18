<template>
    <el-form ref="ruleFormRef" :model="userFormData" :rules="rules" status-icon>
        <el-form-item prop="username">
            <el-input v-model="userFormData.username" placeholder="请输入用户名" />
        </el-form-item>
        <el-form-item prop="email">
            <el-input :disabled="userPinia.userId!==''" v-model="userFormData.email" placeholder="请输入邮箱"></el-input>
        </el-form-item>
        <el-form-item prop="phone">
            <el-input v-model="userFormData.phone" placeholder="请输入手机号"></el-input>
        </el-form-item>
        <el-form-item prop="gender">
            <el-select v-model="userFormData.gender" placeholder="请选择性别">
                <el-option label="男" value="男"></el-option>
                <el-option label="女" value="女"></el-option>
            </el-select>
        </el-form-item>
        <el-form-item prop="gender">
            <el-select v-model="userFormData.userRole" placeholder="请选择用户角色">
                <el-option label="普通用户" value="普通用户"></el-option>
                <el-option label="管理员" value="管理员"></el-option>
            </el-select>
        </el-form-item>
        <el-form-item>
            <el-button style="width: 100%;" type="primary" @click="submitForm(ruleFormRef)">
                提交
            </el-button>
        </el-form-item>
    </el-form>
</template>

<script lang="ts" setup>
import { useRouter } from 'vue-router';
const router = useRouter();
import { onMounted, reactive, ref, watch } from 'vue'
import { ElMessage, type FormInstance, type FormRules } from 'element-plus'
import { registerAPI, updateUserAPI } from '@/api/postAPI';
import { useUserStore } from '@/stores/userStore'
import { storeToRefs } from 'pinia';
import { setUserList } from './ts/user';
const userStore = useUserStore()
const { userPinia } = storeToRefs(userStore)
interface RuleForm {
    username: string;
    email: string;
    phone: string;
    gender: string;
    userRole: string;
    userId: string;
}

const formSize = ref('default')
const ruleFormRef = ref<FormInstance>()
const userFormData = reactive<RuleForm>({
    username: '',
    email: '',
    gender: '男',
    phone: '',
    userRole: '普通用户',
    userId: ''
})
onMounted(() => {
    if (userPinia.value.userId !== '') {
        userFormData.username = userPinia.value.username
        userFormData.email = userPinia.value.email
        userFormData.phone = userPinia.value.phone
        userFormData.gender = userPinia.value.gender
        userFormData.userRole = userPinia.value.userRole
        userFormData.userId = userPinia.value.userId
    }
})
watch(userPinia, () => {
    userFormData.username = userPinia.value.username
    userFormData.email = userPinia.value.email
    userFormData.phone = userPinia.value.phone
    userFormData.gender = userPinia.value.gender
    userFormData.userRole = userPinia.value.userRole
    userFormData.userId = userPinia.value.userId
})
const rules = reactive<FormRules<RuleForm>>({
    username: [
        { required: true, message: '请输入用户名', trigger: 'blur' },
        { min: 2, message: 'Length should be 3 to 5', trigger: 'blur' },
    ],
    email: [
        {
            required: true,
            message: '请输入邮箱地址',
            trigger: 'blur'
        },
        {
            // 标准邮箱正则表达式
            pattern: /^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/,
            message: '请输入正确的邮箱格式',
            trigger: 'blur'
        }
    ],
    phone: [
        {
            required: true,
            message: '请输入手机号',
            trigger: 'blur'
        },
        {
            pattern: /^1[3-9]\d{9}$/,
            message: '请输入正确的手机号格式',
            trigger: 'blur'
        }
    ],
    gender: [
        { required: true, message: '请选择性别', trigger: 'change' }
    ],
    userRole: [
        { required: true, message: '请选择用户角色', trigger: 'change' }
    ]
})

const submitForm = async (formEl: FormInstance | undefined) => {
    if (!formEl) return
    await formEl.validate(async (valid, fields) => {
        if (valid) {
            if (userPinia.value.userId === '') {
                const res = await registerAPI(userFormData)
                if (res.message === '注册成功') {
                    await setUserList(1, null, null) // Refresh the user list after adding
                    ElMessage.success('添加成功')
                } else {
                    ElMessage.error("添加失败")
                }
            }else{
               const res=await updateUserAPI(userFormData)
               if(res.message === '更新成功') {
                    await setUserList(1, null, null) // Refresh the user list after adding
                    ElMessage.success('更新成功')
                } else {
                    ElMessage.error("更新失败")
                }
            }

        } else {
            console.log('error submit!', fields)
        }
    })
}

const resetForm = (formEl: FormInstance | undefined) => {
    if (!formEl) return
    formEl.resetFields()
}

const options = Array.from({ length: 10000 }).map((_, idx) => ({
    value: `${idx + 1}`,
    label: `${idx + 1}`,
}))
</script>
