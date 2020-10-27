﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage3.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    PhoneNum = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpace",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Available = table.Column<bool>(nullable: false),
                    ParkingSpaceNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpace", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<string>(maxLength: 30, nullable: false),
                    FillsNumberOfSpaces = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ParkedVehicle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTypeID = table.Column<int>(nullable: false),
                    MemberID = table.Column<int>(nullable: false),
                    RegNum = table.Column<string>(maxLength: 8, nullable: false),
                    Color = table.Column<string>(maxLength: 30, nullable: false),
                    Make = table.Column<string>(maxLength: 30, nullable: false),
                    Model = table.Column<string>(maxLength: 30, nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkedVehicle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ParkedVehicle_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkedVehicle_VehicleTypes_VehicleTypeID",
                        column: x => x.VehicleTypeID,
                        principalTable: "VehicleTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parking",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkedVehicleID = table.Column<int>(nullable: false),
                    ParkingSpaceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Parking_ParkedVehicle_ParkedVehicleID",
                        column: x => x.ParkedVehicleID,
                        principalTable: "ParkedVehicle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parking_ParkingSpace_ParkingSpaceID",
                        column: x => x.ParkingSpaceID,
                        principalTable: "ParkingSpace",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "ConfirmPassword", "Email", "FirstName", "LastName", "Password", "PhoneNum" },
                values: new object[,]
                {
                    { 1, "plugga", "kalle.kula@hotail.com", "Kalle", "Kula", "plugga", "070234567" },
                    { 2, "plugga2", "and.and@hotail.com", "Andreas", "Andersson", "plugga2", "070234568" },
                    { 3, "plugga3", "zlatan@hotail.com", "Zlatan", "Ibrahimovic", "plugga3", "070234569" }
                });

            migrationBuilder.InsertData(
                table: "ParkingSpace",
                columns: new[] { "ID", "Available", "ParkingSpaceNum" },
                values: new object[,]
                {
                    { 1, false, 1 },
                    { 2, true, 2 },
                    { 3, true, 3 }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "ID", "FillsNumberOfSpaces", "VehicleType" },
                values: new object[,]
                {
                    { 1, 3, "Bus" },
                    { 2, 1, "Car" },
                    { 3, 1, "Sportscar" },
                    { 4, 1, "Motorcycle" }
                });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "ID", "ArrivalTime", "Color", "Make", "MemberID", "Model", "RegNum", "VehicleTypeID" },
                values: new object[] { 1, new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black", "Dodge", 1, "Nitro TR 4/4", "FZK678", 3 });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "ID", "ArrivalTime", "Color", "Make", "MemberID", "Model", "RegNum", "VehicleTypeID" },
                values: new object[] { 2, new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black", "Camaro", 3, "SS", "FZK677", 3 });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "ID", "ArrivalTime", "Color", "Make", "MemberID", "Model", "RegNum", "VehicleTypeID" },
                values: new object[] { 3, new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orange", "Harley Davidson", 2, "NightRod", "MKT677", 4 });

            migrationBuilder.InsertData(
                table: "Parking",
                columns: new[] { "ID", "ParkedVehicleID", "ParkingSpaceID" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicle_MemberID",
                table: "ParkedVehicle",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicle_VehicleTypeID",
                table: "ParkedVehicle",
                column: "VehicleTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Parking_ParkedVehicleID",
                table: "Parking",
                column: "ParkedVehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Parking_ParkingSpaceID",
                table: "Parking",
                column: "ParkingSpaceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parking");

            migrationBuilder.DropTable(
                name: "ParkedVehicle");

            migrationBuilder.DropTable(
                name: "ParkingSpace");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
