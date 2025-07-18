import { deleteRemove } from "./axiosConfig";

export const deleteUserAPI = (id: string): Promise<any> => {
    return deleteRemove(`/UM/User/deleteUser?userId=${id}`);
};
