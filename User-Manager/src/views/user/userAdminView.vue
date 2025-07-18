<template>
    <div style="text-align: right;">
        <el-button type="primary" style="margin-left: 16px" @click="drawer = true">
            添加用户
        </el-button>
    </div>
    <div>
        <userAdminComponent />
    </div>
    <el-drawer v-model="drawer" title="添加用户"   direction="ltr" size="40%"> 
        <addUserComponent />
    </el-drawer>
</template>
<script lang="ts" setup>
import userAdminComponent from '@/components/user/userAdminComponent.vue';
import addUserComponent from '@/components/user/addUserComponent.vue';
import { ref } from 'vue';
const drawer = ref(false);
</script>