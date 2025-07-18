<template>
    <div class="login-container">
        <el-card>
            <template #header>
                <span>登录>>人员管理系统</span>
            </template>
            <loginComponent />
        </el-card>
    </div>
</template>
<script lang="ts" setup>
import loginComponent from '@/components/user/loginComponent.vue';
</script>
<style scoped>
.login-container {
    display: flex;
    justify-content: center;
    align-items: center;
    min-height: 90vh;
}
</style>