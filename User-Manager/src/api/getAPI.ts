import { get } from "./axiosConfig";

export const getUserListAPI = async (pageNumber:any,username:any,gender:any) => {
    console.log(pageNumber)
    const res= await get('/UM/User/userList',{pageNumber:pageNumber,pageSize:10,username:username,gender:gender});
    return res.data
}