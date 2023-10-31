"use client";
import React, { useEffect, useState } from "react";
import useSWR from "swr";
import { fetcher } from "../libs";
import PermissionComponent from "../components/Permission";
import { Permission } from "@/types";
import Link from "next/link";

export default function Permissions() {
  const [permissions, setPermissions] = useState<Permission[]>([]);
  const { data, error, isLoading } = useSWR<any>(`/api/permissions`, fetcher);

  useEffect(() => {
    if (data && data.result.permissions) {
      console.log(data.result.permissions);
      setPermissions(data.result.permissions);
    }
  }, [data, isLoading]);
  if (error) return <div>Failed to load</div>;
  if (isLoading) return <div>Loading...</div>;
  if (!data) return null;
  let delete_Permission: Permission["deletePermission"] = async (
    id: string
  ) => {
    const res = await fetch(`/api/permission/${id}`, {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json",
      },
    });
    const content = await res.json();
    if (content.success > 0) {
      setPermissions(
        permissions?.filter((permission: Permission) => {
          return permission.permissionId !== id;
        })
      );
    }
  };
  return (
    <div className="w-full max-w-7xl m-auto">
      <table className="w-full border-collapse border border-slate-400">
        <caption className="caption-top py-5 font-bold text-green-500 text-2xl">
          Permission List - Counter :
          <span className="text-red-500 font-bold">{permissions?.length}</span>
        </caption>

        <thead>
          <tr className="text-center">
            <th className="border border-slate-300">Permission ID</th>
            <th className="border border-slate-300">Employee Name</th>
            <th className="border border-slate-300">Permission Type</th>
            <th className="border border-slate-300">Created at</th>
            <th className="border border-slate-300">Modify</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td colSpan={10}>
              <Link
                href={`/permission/create`}
                className="bg-green-500 p-2 inline-block text-white"
              >
                New
              </Link>
            </td>
          </tr>
          {permissions &&
            permissions.map((item: Permission) => (
              <PermissionComponent
                key={item.permissionId}
                {...item}
                deletePermission={delete_Permission}
              />
            ))}
        </tbody>
      </table>
    </div>
  );
}
