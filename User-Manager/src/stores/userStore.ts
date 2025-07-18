import { defineStore } from 'pinia'
export const useUserStore = defineStore('userPinia', {
    state: () => ({
        userPinia:{
            userId: '',
            username: '',
            email: '',
            phone: '',
            gender: '',
            userRole: ''
        },
    }),
    actions:{
        clear(){
            this.userPinia = {
                userId: '',
                username: '',
                email: '',
                phone: '',
                gender: '',
                userRole: ''
            }
        }
    },
    persist:{
        key:'user',
        storage:sessionStorage,
        paths:['user']
    }as {
        key: string;
        storage: Storage;
        paths: string[];
    }
})
