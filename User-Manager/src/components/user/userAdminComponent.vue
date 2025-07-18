<template>
    <el-form inline>
        <el-form-item>
            <el-input v-model="searName" placeholder="请输入姓名"></el-input>
        </el-form-item>
        <el-form-item>
            <el-select v-model="searGender" placeholder="请选择性别" style="width: 120px;">
                <el-option label="全部" value=""></el-option>
                <el-option label="男" value="男"></el-option>
                <el-option label="女" value="女"></el-option>
            </el-select>
        </el-form-item>
        <el-form-item>
            <el-button type="primary" @click="searchUsers">搜索</el-button>
        </el-form-item>
    </el-form>
    <el-table :data="userList" style="width: 100%">
        <el-table-column prop="username" label="姓名" />
        <el-table-column prop="email" label="邮箱" />
        <el-table-column prop="gender" label="性别" />
        <el-table-column prop="phone" label="电话" />
        <el-table-column prop="userRole" label="用户类别" />
        <el-table-column label="Operations">
            <template #default="scope">
                <el-button size="small" @click="handleChange(scope.row)">修改</el-button>
                <el-button size="small" type="danger" @click="deleteUser(scope.row.userId)">删除</el-button>
            </template>
        </el-table-column>
    </el-table>
    <paging-component />

    <el-drawer v-model="drawer" title="添加用户" direction="ltr" @close="handelClose" size="40%">
        <addUserComponent />
    </el-drawer>
</template>

<script lang="ts" setup>
import addUserComponent from '@/components/user/addUserComponent.vue'
import { deleteUserAPI } from '@/api/deleteAPI'
import pagingComponent from '../pagingComponent.vue'
import { getUserListAPI } from '@/api/getAPI'
import { ElMessage } from 'element-plus'
import { onMounted } from 'vue'
import { ref } from 'vue'
const searName = ref('')
const searGender = ref('')
const drawer = ref(false)
import { usepaginationStore } from '@/stores/paginationStore'
import { storeToRefs } from 'pinia'
import { setUserList } from './ts/user'
const paginationStore = usepaginationStore()
const { pageData, userList } = storeToRefs(paginationStore)
onMounted(async () => {
    await setUserList(1, null, null)
})
const deleteUser = async (userId: string) => {
    const res = await deleteUserAPI(userId)
    if (res.data = true) {
        ElMessage.success('删除成功')
        await setUserList(pageData.value.currentPage, null, null) // Refresh the user list after deletion
    } else {
        ElMessage.error('删除失败')
    }
}
const searchUsers = async () => {
    await setUserList(1, searName.value, searGender.value)
}
import { useUserStore } from '@/stores/userStore'
const userStore = useUserStore()
const { userPinia } = storeToRefs(userStore)
const handleChange = (row: any) => {
    userPinia.value = row
    drawer.value = true
    console.log(userPinia.value)
}
const handelClose = () => {
    userPinia.value = {
        userId: '',
        username: '',
        email: '',
        phone: '',
        gender: '',
        userRole: ''
    }
}
</script>
