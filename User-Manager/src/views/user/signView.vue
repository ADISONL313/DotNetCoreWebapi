<template>
    <div class="login-container">
        <el-card>
            <template #header>
                <span>注册</span>
            </template>
            <signUpComponent />
        </el-card>
    </div>
</template>
<script lang="ts" setup>
import signUpComponent from '@/components/user/signUpComponent.vue'
</script>
<style scoped>
.login-container {
    display: flex;
    justify-content: center;
    align-items: center;
    min-height: 90vh;
}
</style>