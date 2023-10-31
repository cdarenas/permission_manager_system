"use client";
import React, { useState } from "react";
import { useRouter } from "next/navigation";
export default function PermissionCreate() {
  const router = useRouter();
  const [employeeFirstName, setEmployeeFirstName] = useState<string>("");
  const [employeeLastName, setEmployeeLastName] = useState<string>("");
  const [permissionType, setPermissionType] = useState<string>("");

  const addPermission = async (e: any) => {
    e.preventDefault();
    if (
      employeeFirstName != "" &&
      employeeLastName != "" &&
      permissionType != ""
    ) {
      const formData = {
        employeeFirstName: employeeFirstName,
        employeeLastName: employeeLastName,
        permissionType: permissionType,
      };
      const add = await fetch('http://localhost:5010/api/v1/NewPermission', {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(formData),
      });
      const content = await add.json();
      if (content.message) {
        router.push("/permission");
      }
    }
  };
  return (
    <form className="w-full" onSubmit={addPermission}>
      <span className="font-bold text-yellow-500 py-2 block underline text-2xl">
        Form New Permission
      </span>
      <div className="w-full py-2">
        <label htmlFor="" className="text-sm font-bold py-2 block">
          Employee First Name
        </label>
        <input
          type="text"
          name="employeeFirstName"
          className="w-full border-[1px] border-gray-200 p-2 rounded-sm"
          onChange={(e: any) => setEmployeeFirstName(e.target.value)}
        />
      </div>
      <div className="w-full py-2">
        <label htmlFor="" className="text-sm font-bold py-2 block">
          Employee Last Name
        </label>
        <input
          name="employeeLastName"
          className="w-full border-[1px] border-gray-200 p-2 rounded-sm"
          onChange={(e: any) => setEmployeeLastName(e.target.value)}
        />
      </div>
      <div className="w-full py-2">
        <label htmlFor="" className="text-sm font-bold py-2 block">
          Permission Type Id
        </label>
        <input
          name="permissionType"
          className="w-full border-[1px] border-gray-200 p-2 rounded-sm"
          onChange={(e: any) => setPermissionType(e.target.value)}
        />
      </div>
      <div className="w-full py-2">
        <button className="w-20 p-2 text-white border-gray-200 border-[1px] rounded-sm bg-green-400">
          Submit
        </button>
      </div>
    </form>
  );
}
