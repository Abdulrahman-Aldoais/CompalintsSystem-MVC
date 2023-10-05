using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompalintsSystem.EF.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b82ccec-04ab-4a7e-befd-5cf76e4e7048");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "145218e7-6205-4dd3-a12c-3c6ddb030aea");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7164deb2-84e2-48eb-81d7-f1e831ecf022");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6fc11c4-281b-4480-a395-743a5c5d2e3e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f88d931c-5ea0-41b9-ad92-c6dcaf5ed337");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationUserId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48e9b2f6-42e7-439f-afa2-03cf13342517", null, "2e591243-d191-415e-8e0b-472f1cd9b51d", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "2afd97e1-b763-4a31-9a5a-0ed57efd7a04", null, "a7bf984e-2474-4c05-a410-ce9e7de97221", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "f4af62bf-7d40-483a-8ec2-8fa0e94b8337", null, "6b426ab9-0e5e-4118-baab-a30ef5068b03", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "2031d8ec-c362-4f84-8e3e-97a28b8db091", null, "03afe4c9-7e22-4125-bd88-4a57d1185efd", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "b7d0b985-a65a-4490-9789-58bb772c1386", null, "f5b1cfef-09b1-4b28-aea9-609b87b09c10", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 17, 39, 24, 198, DateTimeKind.Local).AddTicks(5974));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 17, 39, 24, 198, DateTimeKind.Local).AddTicks(6010));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 17, 39, 24, 200, DateTimeKind.Local).AddTicks(4010));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 17, 39, 24, 200, DateTimeKind.Local).AddTicks(4893));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2031d8ec-c362-4f84-8e3e-97a28b8db091");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2afd97e1-b763-4a31-9a5a-0ed57efd7a04");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48e9b2f6-42e7-439f-afa2-03cf13342517");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7d0b985-a65a-4490-9789-58bb772c1386");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4af62bf-7d40-483a-8ec2-8fa0e94b8337");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationUserId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b82ccec-04ab-4a7e-befd-5cf76e4e7048", null, "10bf3200-a415-4cf4-a804-09364830fa4e", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "c6fc11c4-281b-4480-a395-743a5c5d2e3e", null, "c78f0644-bffa-4072-8670-4adf06f11267", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "f88d931c-5ea0-41b9-ad92-c6dcaf5ed337", null, "0d4cec7f-7664-4ef2-8828-212ef8e26a22", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "145218e7-6205-4dd3-a12c-3c6ddb030aea", null, "77bed017-7ebf-4ac5-aafc-58e6975c1d2e", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "7164deb2-84e2-48eb-81d7-f1e831ecf022", null, "973fa615-ad51-45c6-9efc-bca84c30b9e3", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 14, 49, 26, 328, DateTimeKind.Local).AddTicks(1851));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeCommunications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 14, 49, 26, 328, DateTimeKind.Local).AddTicks(1873));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 14, 49, 26, 329, DateTimeKind.Local).AddTicks(117));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 14, 49, 26, 329, DateTimeKind.Local).AddTicks(538));
        }
    }
}
