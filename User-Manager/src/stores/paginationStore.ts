import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
interface PageData {
    currentPage: number
    pageSize: number
    totalItems: number
    totalPage: number
}
interface User {
    userId: string
    username: string
    email: string
    phone: string
    gender: string
    userRole: string
    createAt: string
}
export const usepaginationStore = defineStore('pagenation', {
    state: () => ({
        pageData:{
            currentPage: 1,
            pageSize: 10,
            totalItems: 0,
            totalPage: 1
        } as PageData,
        userList:[] as User[]
    })
})
