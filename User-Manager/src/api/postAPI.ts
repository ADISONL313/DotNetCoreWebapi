import { post } from "./axiosConfig"

export const registerAPI=async(user:any)=>{
    return await post('/UM/User/register',user)
}
export const loginAPI=async(user:any)=>{
    return await post('/UM/User/login',user)
}
export const updateUserAPI=async(user:any)=>{
    return await post('/UM/User/updateUser',user)
}