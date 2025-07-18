import { getUserListAPI } from '@/api/getAPI'
import { usepaginationStore } from '@/stores/paginationStore'
import { storeToRefs } from 'pinia'
const paginationStore = usepaginationStore()
const { pageData, userList } = storeToRefs(paginationStore)
export const setUserList=async (pageNumber:any,username: any, gender: any) => {
    const res = await getUserListAPI(pageNumber,username, gender)
    pageData.value.currentPage=res.currentPage
    pageData.value.pageSize=res.pageSize
    pageData.value.totalItems=res.totalItems
    pageData.value.totalPage=res.totalPage
    userList.value = res.items
}