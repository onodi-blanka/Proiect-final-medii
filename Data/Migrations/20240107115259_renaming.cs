using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Data.Migrations
{
    public partial class renaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Doctor_DoctorID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Pet_PetID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Appointment_AppointmentID",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Owner_OwnerID",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatment_Appointment_AppointmentID",
                table: "Treatment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treatment",
                table: "Treatment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pet",
                table: "Pet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owner",
                table: "Owner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "Treatment",
                newName: "Treatments");

            migrationBuilder.RenameTable(
                name: "Pet",
                newName: "Pets");

            migrationBuilder.RenameTable(
                name: "Owner",
                newName: "Owners");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.RenameTable(
                name: "Doctor",
                newName: "Doctors");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_Treatment_AppointmentID",
                table: "Treatments",
                newName: "IX_Treatments_AppointmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_OwnerID",
                table: "Pets",
                newName: "IX_Pets_OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_AppointmentID",
                table: "Invoices",
                newName: "IX_Invoices_AppointmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_PetID",
                table: "Appointments",
                newName: "IX_Appointments_PetID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_DoctorID",
                table: "Appointments",
                newName: "IX_Appointments_DoctorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treatments",
                table: "Treatments",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pets",
                table: "Pets",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorID",
                table: "Appointments",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Pets_PetID",
                table: "Appointments",
                column: "PetID",
                principalTable: "Pets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Appointments_AppointmentID",
                table: "Invoices",
                column: "AppointmentID",
                principalTable: "Appointments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Owners_OwnerID",
                table: "Pets",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Appointments_AppointmentID",
                table: "Treatments",
                column: "AppointmentID",
                principalTable: "Appointments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Pets_PetID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Appointments_AppointmentID",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Owners_OwnerID",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Appointments_AppointmentID",
                table: "Treatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treatments",
                table: "Treatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pets",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "Treatments",
                newName: "Treatment");

            migrationBuilder.RenameTable(
                name: "Pets",
                newName: "Pet");

            migrationBuilder.RenameTable(
                name: "Owners",
                newName: "Owner");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "Doctor");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Appointment");

            migrationBuilder.RenameIndex(
                name: "IX_Treatments_AppointmentID",
                table: "Treatment",
                newName: "IX_Treatment_AppointmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_OwnerID",
                table: "Pet",
                newName: "IX_Pet_OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_AppointmentID",
                table: "Invoice",
                newName: "IX_Invoice_AppointmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PetID",
                table: "Appointment",
                newName: "IX_Appointment_PetID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DoctorID",
                table: "Appointment",
                newName: "IX_Appointment_DoctorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treatment",
                table: "Treatment",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pet",
                table: "Pet",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owner",
                table: "Owner",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Doctor_DoctorID",
                table: "Appointment",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Pet_PetID",
                table: "Appointment",
                column: "PetID",
                principalTable: "Pet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Appointment_AppointmentID",
                table: "Invoice",
                column: "AppointmentID",
                principalTable: "Appointment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Owner_OwnerID",
                table: "Pet",
                column: "OwnerID",
                principalTable: "Owner",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatment_Appointment_AppointmentID",
                table: "Treatment",
                column: "AppointmentID",
                principalTable: "Appointment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
