import { Role } from "./role";

export interface User {
    isDeleted: boolean;
    email: string;
    username: string;
    isEmailConfirmed: boolean;
    password: string;
    role : Role;
}
