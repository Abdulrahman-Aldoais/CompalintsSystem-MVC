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
                keyValue: "029fa55c-bd64-4868-8625-a3fef2548486");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e1399ea-e93d-4b5f-9cfd-e793af7af7c3");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "132e197c-c0f4-46e7-a092-1e189d1457c0");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e39f86c-3bb5-4468-92d7-efab8e345535");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac7580d8-1ad0-4f55-a892-e042d08864ab");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationUserId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c308e7e8-1cc1-4259-bf8d-c9793649b64d", null, "c1e68535-6ecc-425f-a0e8-ad5c60eb5685", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "15dac985-7a4e-4161-8e29-ec1b83e4c5c1", null, "f36f8c30-5f08-46ae-a884-fa0fc8cd9e2f", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "45620b69-0c35-4fda-9679-e38ed6c52f4a", null, "f8fd99e7-5724-4ca5-b828-f867c5b27514", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "4228c258-b5fa-47f9-9c7f-fd90bf3b9a43", null, "6807c4ad-baa5-451e-95c8-aa6c2736e485", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "4578c7ee-de60-400d-a7ee-1c0048291632", null, "9209b3df-f9af-44fd-89d8-53fec43919c6", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 0, 59, 11, 850, DateTimeKind.Local).AddTicks(7422));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 0, 59, 11, 850, DateTimeKind.Local).AddTicks(7458));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 0, 59, 11, 852, DateTimeKind.Local).AddTicks(693));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 0, 59, 11, 852, DateTimeKind.Local).AddTicks(1538));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15dac985-7a4e-4161-8e29-ec1b83e4c5c1");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4228c258-b5fa-47f9-9c7f-fd90bf3b9a43");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45620b69-0c35-4fda-9679-e38ed6c52f4a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4578c7ee-de60-400d-a7ee-1c0048291632");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c308e7e8-1cc1-4259-bf8d-c9793649b64d");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationUserId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e1399ea-e93d-4b5f-9cfd-e793af7af7c3", null, "910576a7-cf48-4a09-b475-4bb27565afbb", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "132e197c-c0f4-46e7-a092-1e189d1457c0", null, "cca303a9-61e6-472c-93f2-5e9b67126757", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "ac7580d8-1ad0-4f55-a892-e042d08864ab", null, "50645ca1-b3b9-4979-81c5-4f76bfa9abed", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "9e39f86c-3bb5-4468-92d7-efab8e345535", null, "c715d220-494b-47b5-959e-d950b2178413", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "029fa55c-bd64-4868-8625-a3fef2548486", null, "175e37de-83f9-414c-811b-72370e67154e", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 6, 23, 20, 33, 976, DateTimeKind.Local).AddTicks(324));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 6, 23, 20, 33, 976, DateTimeKind.Local).AddTicks(395));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 6, 23, 20, 33, 977, DateTimeKind.Local).AddTicks(5179));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 6, 23, 20, 33, 977, DateTimeKind.Local).AddTicks(5994));
        }
    }
}
