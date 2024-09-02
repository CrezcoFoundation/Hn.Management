import { Role } from "./role";

export interface User {
    id: string;
    isDeleted?: boolean;
    email?: string;
    username?: string;
    isEmailConfirmed?: boolean;
    password?: string;
    role?: Role;
    jwtToken?: string;
}
