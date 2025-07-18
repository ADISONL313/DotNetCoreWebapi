<template>
    <el-pagination :page-size="pageData.pageSize" :page-count="pageData.totalPage" :current-page="pageData.currentPage"
        @size-change="handleSizeChange" @current-change="handleCurrentChange" style="justify-content: center;"
        background layout="prev, pager, next" :total="1000" />
</template>
<script lang="ts" setup>
import { usepaginationStore } from '@/stores/paginationStore'
import { storeToRefs } from 'pinia'
import { setUserList } from './user/ts/user'
const paginationStore = usepaginationStore()
const { pageData } = storeToRefs(paginationStore)
const handleSizeChange = (val: number) => {
    console.log(`${val} items per page`)
}
const handleCurrentChange = async(val: number) => {
    await setUserList(val, null, null)
}
</script>