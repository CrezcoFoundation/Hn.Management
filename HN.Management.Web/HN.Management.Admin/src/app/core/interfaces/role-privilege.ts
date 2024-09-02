export interface RolePrivilege {
    name: string;
    isDeleted: boolean;
}

export interface RolePrivilegeRequest {
    roleId: string;
    privilagesIds: string [];
}
