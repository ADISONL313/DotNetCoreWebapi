<template>
    <el-form  ref="ruleFormRef" style="width: 480px;" :model="userFormData" :rules="rules" status-icon>
        <el-form-item prop="email">
            <el-input v-model="userFormData.email" placeholder="请输入邮箱"></el-input>
        </el-form-item>
        <el-form-item prop="password">
            <el-input v-model="userFormData.password" placeholder="请输入密码" type="password"></el-input>
        </el-form-item>
        <el-form-item>
            <el-button  link style="color: #409EFF;width: 100%;" @click="router.push('/signUp')">去注册</el-button>
        </el-form-item>
        <el-form-item>
            <el-button style="width: 100%;" type="primary" @click="submitForm(ruleFormRef)">
                登录
            </el-button>
        </el-form-item>
    </el-form>
</template>

<script lang="ts" setup>
import { useRouter } from 'vue-router';
const router = useRouter();
import { reactive, ref } from 'vue'
import type { FormInstance, FormRules } from 'element-plus'
import { loginAPI, registerAPI } from '@/api/postAPI';

interface RuleForm {
    email: string;
    password: string;
}

const formSize = ref('default')
const ruleFormRef = ref<FormInstance>()
const userFormData = reactive<RuleForm>({
    email: '',
    password: ''
})

const rules = reactive<FormRules<RuleForm>>({
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
    ]
})

const submitForm = async (formEl: FormInstance | undefined) => {
    if (!formEl) return
    await formEl.validate(async (valid, fields) => {
        if (valid) {
            const res = await loginAPI(userFormData)
            if(res.message==='登录成功'){
                sessionStorage.setItem('token', res.data.token)
                sessionStorage.setItem('userId', res.data.userId)
                sessionStorage.setItem('email', res.data.email)
                console.log('登录成功:', sessionStorage.getItem('token'))
                router.push('/userAdmin')
            } else {
                console.error('登录失败:', res.message)
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
