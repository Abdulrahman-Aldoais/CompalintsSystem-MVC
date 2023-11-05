using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompalintsSystem.EF.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b0fc9d2-3783-4c3b-a0b8-0c80c773dfa4");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34a77758-8402-4104-ae1a-14e854d90f38");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fd906ab-a068-4439-8568-654ad2a7c27c");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b5dd56a-1501-4ac2-bc37-2e390ed3febd");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb18d034-2618-466c-a8a1-203e4b85e120");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationUserId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21d02983-458d-476b-b605-dfe74d5deace", null, "42915cbe-6e2c-46b3-9f0b-d35b558acecc", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "2ac99673-1f3c-405d-8a41-33c37a6718d7", null, "3c819767-e17c-43ab-8da9-5e41df673c11", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "e7ca9b9e-8a34-4577-908a-45d4aee701d7", null, "7c85c292-c802-4292-8be9-fd8178f1c197", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "00faaa58-6b68-4510-be19-cb69af6e4291", null, "1c886262-8844-4eda-957d-45b43dd34027", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "64eadfed-a6fb-41fb-9948-cfefce90392f", null, "3c25ef9a-cdd8-4637-932c-596169b874aa", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 0, 9, 1, 862, DateTimeKind.Local).AddTicks(8229));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 0, 9, 1, 862, DateTimeKind.Local).AddTicks(8261));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 0, 9, 1, 863, DateTimeKind.Local).AddTicks(8841));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 0, 9, 1, 863, DateTimeKind.Local).AddTicks(9568));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00faaa58-6b68-4510-be19-cb69af6e4291");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21d02983-458d-476b-b605-dfe74d5deace");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ac99673-1f3c-405d-8a41-33c37a6718d7");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64eadfed-a6fb-41fb-9948-cfefce90392f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7ca9b9e-8a34-4577-908a-45d4aee701d7");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationUserId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34a77758-8402-4104-ae1a-14e854d90f38", null, "f1565658-2aea-47ef-9949-49b4303fff6b", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "9b5dd56a-1501-4ac2-bc37-2e390ed3febd", null, "019cb24e-adba-4d33-9efb-a15ddcdff40f", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "0b0fc9d2-3783-4c3b-a0b8-0c80c773dfa4", null, "ad2550b8-7990-4eb3-abcb-dc064181181f", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "fb18d034-2618-466c-a8a1-203e4b85e120", null, "32b6a1a3-d9bd-4a5d-86e1-6025bd7076de", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "5fd906ab-a068-4439-8568-654ad2a7c27c", null, "45bc40a9-7f6d-47ce-9923-d6a67d02414f", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 4, 23, 59, 35, 494, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 4, 23, 59, 35, 494, DateTimeKind.Local).AddTicks(4547));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 4, 23, 59, 35, 497, DateTimeKind.Local).AddTicks(9748));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 4, 23, 59, 35, 498, DateTimeKind.Local).AddTicks(1674));
        }
    }
}
