import React from "react";
import { Permission } from "@/types";
import Link from "next/link";
export default function PermissionComponent(params: Permission) {
  return (
    <tr>
      <td className="w-10 border border-slate-300 text-center">
        {params.permissionId}
      </td>
      <td className="border border-slate-300">
        {params.employeeFirstName} {params.employeeLastName}
      </td>
      <td className="border border-slate-300 text-center">
        {params.permissionTypeEntity.description}
      </td>
      <td className="border border-slate-300 text-center">
        {params.createdDate}
      </td>
      <td className="w-52 border border-slate-300">
        <span className="bg-red-500 p-2 inline-block text-white text-sm">
          Revoke
        </span>
        <Link
          href="#"
          className="bg-yellow-500 p-2 inline-block ml-3 text-white text-sm"
        >
          Modify
        </Link>
        <Link
          href="#"
          className="bg-yellow-500 p-2 inline-block ml-3 text-white text-sm"
        >
          View
        </Link>
      </td>
    </tr>
  );
}
