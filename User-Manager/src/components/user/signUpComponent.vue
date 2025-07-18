<template>
    <el-form style="width: 480px;"  ref="ruleFormRef" :model="userFormData" :rules="rules" status-icon>
        <el-form-item  prop="username">
            <el-input v-model="userFormData.username" placeholder="请输入用户名" />
        </el-form-item>
        <el-form-item  prop="email">
            <el-input v-model="userFormData.email" placeholder="请输入邮箱" ></el-input>
        </el-form-item>
        <el-form-item  prop="password">
            <el-input v-model="userFormData.password" placeholder="请输入密码,密码必须包含字母和数字" type="password"></el-input>
        </el-form-item>
        <el-form-item  prop="confirmPassword">
            <el-input v-model="userFormData.confirmPassword" placeholder="请确认密码" type="password"></el-input>
        </el-form-item>
        <el-form-item>
            <el-button  link style="color: #409EFF;width: 100%;" @click="router.back()">返回登录</el-button>
        </el-form-item>
        <el-form-item>
            <el-button style="width: 100%;" type="primary" @click="submitForm(ruleFormRef)">
                注册
            </el-button>
        </el-form-item>
    </el-form>
</template>

<script lang="ts" setup>
import { useRouter } from 'vue-router';
const router = useRouter();
import { reactive, ref } from 'vue'
import type { FormInstance, FormRules } from 'element-plus'
import { registerAPI } from '@/api/postAPI';

interface RuleForm {
    username: string;
    email: string;
    password: string;
    confirmPassword: string;
}

const formSize = ref('default')
const ruleFormRef = ref<FormInstance>()
const userFormData = reactive<RuleForm>({
    username: '',
    email: '',
    password: '',
    confirmPassword: '',
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
    password: [
        { 
            required: true, 
            message: '请输入密码', 
            trigger: 'blur' 
        },
        { 
            min: 6, 
            max: 20, 
            message: '密码长度应在6-20个字符之间', 
            trigger: 'blur' 
        },
        {
            // 密码复杂度验证：至少包含字母和数字
            pattern: /^(?=.*[A-Za-z])(?=.*\d).+$/,
            message: '密码必须包含字母和数字',
            trigger: 'blur'
        }
    ],
    confirmPassword: [
        { 
            required: true, 
            message: '请再次输入密码', 
            trigger: 'blur' 
        },
        {
            // 自定义验证器：检查两次输入是否一致
            validator: (rule, value, callback) => {
                if (value !== userFormData.password) {
                    callback(new Error('两次输入的密码不一致'));
                } else {
                    callback(); // 验证通过
                }
            },
            trigger: 'blur'
        }
    ]
})

const submitForm = async (formEl: FormInstance | undefined) => {
    if (!formEl) return
    await formEl.validate(async (valid, fields) => {
        if (valid) {
            const res = await registerAPI(userFormData)
            console.log('注册结果:', res)
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
