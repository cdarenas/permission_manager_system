export interface PermissionTypeEntity {
    permissionTypeId: string
    description: string
}

export interface Permission {
    permissionId: string
    permissionTypeId: string
    permissionTypeEntity: PermissionTypeEntity
    employeeFirstName: string
    employeeLastName: string
    createdDate: string
    deletePermission: (id: string) => void;
}