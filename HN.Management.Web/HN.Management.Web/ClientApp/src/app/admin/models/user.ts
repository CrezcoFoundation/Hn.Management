import { Role } from "./role";

export interface User {
    IsDeleted: boolean;
    Email: string;
    Username: string;
    IsEmailConfirmed: boolean;
    Password: string;
    Role : Role;
}
