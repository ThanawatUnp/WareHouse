using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Authentication.Migrations
{
    public partial class WM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    category_name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    active = table.Column<bool>(nullable: false),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: true),
                    user_define1 = table.Column<string>(nullable: true),
                    user_define2 = table.Column<string>(nullable: true),
                    user_define3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemReceivedState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    state = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemReceivedState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    category_name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: true),
                    user_define1 = table.Column<string>(nullable: true),
                    user_define2 = table.Column<string>(nullable: true),
                    user_define3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_type = table.Column<string>(nullable: false),
                    type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Province_Code = table.Column<string>(nullable: true),
                    Province_Thai = table.Column<string>(nullable: true),
                    Province_Eng = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QueueType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusInboundOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    InboundOrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusInboundOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusInventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    InventoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusInventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusOutboundOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    OutboundOrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOutboundOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMangement",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    reset_state = table.Column<string>(nullable: false),
                    language = table.Column<string>(nullable: true),
                    action = table.Column<string>(nullable: true),
                    sub_action = table.Column<string>(nullable: true),
                    token = table.Column<string>(nullable: true),
                    user_define1 = table.Column<string>(nullable: true),
                    user_define2 = table.Column<string>(nullable: true),
                    user_define3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMangement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    location_code = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    mix_expire = table.Column<bool>(nullable: false),
                    mix_item = table.Column<bool>(nullable: false),
                    mix_lot = table.Column<bool>(nullable: false),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: true),
                    user_define1 = table.Column<string>(nullable: true),
                    user_define2 = table.Column<string>(nullable: true),
                    user_define3 = table.Column<string>(nullable: true),
                    LocationCategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_LocationCategory_LocationCategoryId",
                        column: x => x.LocationCategoryId,
                        principalTable: "LocationCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    District_Code = table.Column<string>(nullable: true),
                    District_Thai = table.Column<string>(nullable: true),
                    District_Eng = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    item_code = table.Column<string>(nullable: false),
                    item_name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    cost = table.Column<double>(nullable: true),
                    unit = table.Column<int>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: true),
                    file_name = table.Column<string>(nullable: true),
                    user_define1 = table.Column<string>(nullable: true),
                    user_define2 = table.Column<string>(nullable: true),
                    user_define3 = table.Column<string>(nullable: true),
                    ItemCategoryId = table.Column<Guid>(nullable: false),
                    QueueTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_ItemCategory_ItemCategoryId",
                        column: x => x.ItemCategoryId,
                        principalTable: "ItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_QueueType_QueueTypeId",
                        column: x => x.QueueTypeId,
                        principalTable: "QueueType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubDistrict",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubDistrict_Code = table.Column<string>(nullable: true),
                    SubDistrict_Thai = table.Column<string>(nullable: true),
                    SubDistrict_Eng = table.Column<string>(nullable: true),
                    zipcode = table.Column<string>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDistrict", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDistrict_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    customer_code = table.Column<string>(nullable: false),
                    customer_name = table.Column<string>(nullable: false),
                    category = table.Column<string>(nullable: true),
                    priority = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    address1 = table.Column<string>(nullable: true),
                    address2 = table.Column<string>(nullable: true),
                    address3 = table.Column<string>(nullable: true),
                    zipcode = table.Column<string>(nullable: true),
                    phone_no = table.Column<string>(nullable: true),
                    mobile_no = table.Column<string>(nullable: true),
                    fax_no = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true),
                    active = table.Column<bool>(nullable: false),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: true),
                    file_name = table.Column<string>(nullable: true),
                    user_define1 = table.Column<string>(nullable: true),
                    user_define2 = table.Column<string>(nullable: true),
                    user_define3 = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    SubDistrictId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_SubDistrict_SubDistrictId",
                        column: x => x.SubDistrictId,
                        principalTable: "SubDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    supplier_code = table.Column<string>(nullable: false),
                    supplier_name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    category = table.Column<string>(nullable: true),
                    priority = table.Column<string>(nullable: true),
                    address1 = table.Column<string>(nullable: true),
                    address2 = table.Column<string>(nullable: true),
                    address3 = table.Column<string>(nullable: true),
                    zipcode = table.Column<string>(nullable: true),
                    phone_no = table.Column<string>(nullable: true),
                    mobile_no = table.Column<string>(nullable: true),
                    fax_no = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true),
                    active = table.Column<bool>(nullable: false),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: true),
                    user_define1 = table.Column<string>(nullable: true),
                    user_define2 = table.Column<string>(nullable: true),
                    user_define3 = table.Column<string>(nullable: true),
                    file_name = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    SubDistrictId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplier_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplier_SubDistrict_SubDistrictId",
                        column: x => x.SubDistrictId,
                        principalTable: "SubDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OutboundOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    order_no = table.Column<string>(nullable: false),
                    plan_ship_date = table.Column<DateTime>(nullable: true),
                    invoice_no = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: true),
                    cancel_by = table.Column<string>(nullable: true),
                    cancel_date = table.Column<DateTime>(nullable: true),
                    cancel_remark = table.Column<string>(nullable: true),
                    user_define1 = table.Column<string>(nullable: true),
                    user_define2 = table.Column<string>(nullable: true),
                    user_define3 = table.Column<string>(nullable: true),
                    OrderTypeId = table.Column<int>(nullable: false),
                    StatusOutboundOrderId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboundOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutboundOrder_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutboundOrder_OrderType_OrderTypeId",
                        column: x => x.OrderTypeId,
                        principalTable: "OrderType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutboundOrder_StatusOutboundOrder_StatusOutboundOrderId",
                        column: x => x.StatusOutboundOrderId,
                        principalTable: "StatusOutboundOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InboundOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    order_no = table.Column<string>(nullable: false),
                    expect_date = table.Column<DateTime>(nullable: false),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: true),
                    close_by = table.Column<string>(nullable: true),
                    close_date = table.Column<DateTime>(nullable: true),
                    close_remark = table.Column<string>(nullable: true),
                    user_define1 = table.Column<string>(nullable: true),
                    user_define2 = table.Column<string>(nullable: true),
                    user_define3 = table.Column<string>(nullable: true),
                    OrderTypeId = table.Column<int>(nullable: false),
                    StatusInboundOrderId = table.Column<Guid>(nullable: false),
                    SupplierId = table.Column<Guid>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboundOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InboundOrder_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InboundOrder_OrderType_OrderTypeId",
                        column: x => x.OrderTypeId,
                        principalTable: "OrderType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InboundOrder_StatusInboundOrder_StatusInboundOrderId",
                        column: x => x.StatusInboundOrderId,
                        principalTable: "StatusInboundOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InboundOrder_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OutboundItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    cost = table.Column<double>(nullable: true),
                    qty = table.Column<int>(nullable: false),
                    remain_qty = table.Column<int>(nullable: false),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: true),
                    user_define1 = table.Column<string>(nullable: true),
                    user_define2 = table.Column<string>(nullable: true),
                    user_define3 = table.Column<string>(nullable: true),
                    OutboundOrderId = table.Column<Guid>(nullable: false),
                    ItemId = table.Column<Guid>(nullable: false),
                    ItemReceivedStateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboundItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutboundItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutboundItem_ItemReceivedState_ItemReceivedStateId",
                        column: x => x.ItemReceivedStateId,
                        principalTable: "ItemReceivedState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutboundItem_OutboundOrder_OutboundOrderId",
                        column: x => x.OutboundOrderId,
                        principalTable: "OutboundOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InboundItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    line_no = table.Column<string>(nullable: true),
                    cost = table.Column<double>(nullable: true),
                    qty = table.Column<int>(nullable: false),
                    remain_qty = table.Column<int>(nullable: false),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: true),
                    user_define1 = table.Column<string>(nullable: true),
                    user_define2 = table.Column<string>(nullable: true),
                    user_define3 = table.Column<string>(nullable: true),
                    InboundOrderId = table.Column<Guid>(nullable: false),
                    ItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboundItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InboundItem_InboundOrder_InboundOrderId",
                        column: x => x.InboundOrderId,
                        principalTable: "InboundOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InboundItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemReceived",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    cost = table.Column<double>(nullable: true),
                    receive_qty = table.Column<int>(nullable: false),
                    remain_putaway = table.Column<int>(nullable: false),
                    lot_no = table.Column<string>(nullable: true),
                    expire_date = table.Column<DateTime>(nullable: true),
                    receive_date = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    edit_by = table.Column<string>(nullable: true),
                    edit_date = table.Column<DateTime>(nullable: true),
                    user_define1 = table.Column<string>(nullable: true),
                    user_define2 = table.Column<string>(nullable: true),
                    user_define3 = table.Column<string>(nullable: true),
                    InboundItemId = table.Column<Guid>(nullable: false),
                    ItemReceivedStateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemReceived", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemReceived_InboundItem_InboundItemId",
                        column: x => x.InboundItemId,
                        principalTable: "InboundItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemReceived_ItemReceivedState_ItemReceivedStateId",
                        column: x => x.ItemReceivedStateId,
                        principalTable: "ItemReceivedState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    qty = table.Column<int>(nullable: false),
                    user_define1 = table.Column<string>(nullable: true),
                    user_define2 = table.Column<string>(nullable: true),
                    user_define3 = table.Column<string>(nullable: true),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false),
                    ItemReceivedId = table.Column<Guid>(nullable: false),
                    StatusInventoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_ItemReceived_ItemReceivedId",
                        column: x => x.ItemReceivedId,
                        principalTable: "ItemReceived",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_StatusInventory_StatusInventoryId",
                        column: x => x.StatusInventoryId,
                        principalTable: "StatusInventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_DistrictId",
                table: "Customer",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ProvinceId",
                table: "Customer",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_SubDistrictId",
                table: "Customer",
                column: "SubDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_District_ProvinceId",
                table: "District",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_InboundItem_InboundOrderId",
                table: "InboundItem",
                column: "InboundOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InboundItem_ItemId",
                table: "InboundItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InboundOrder_CustomerId",
                table: "InboundOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InboundOrder_OrderTypeId",
                table: "InboundOrder",
                column: "OrderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InboundOrder_StatusInboundOrderId",
                table: "InboundOrder",
                column: "StatusInboundOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InboundOrder_SupplierId",
                table: "InboundOrder",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ItemReceivedId",
                table: "Inventory",
                column: "ItemReceivedId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_LocationId",
                table: "Inventory",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_StatusInventoryId",
                table: "Inventory",
                column: "StatusInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemCategoryId",
                table: "Item",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_QueueTypeId",
                table: "Item",
                column: "QueueTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReceived_InboundItemId",
                table: "ItemReceived",
                column: "InboundItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReceived_ItemReceivedStateId",
                table: "ItemReceived",
                column: "ItemReceivedStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_LocationCategoryId",
                table: "Location",
                column: "LocationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundItem_ItemId",
                table: "OutboundItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundItem_ItemReceivedStateId",
                table: "OutboundItem",
                column: "ItemReceivedStateId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundItem_OutboundOrderId",
                table: "OutboundItem",
                column: "OutboundOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundOrder_CustomerId",
                table: "OutboundOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundOrder_OrderTypeId",
                table: "OutboundOrder",
                column: "OrderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundOrder_StatusOutboundOrderId",
                table: "OutboundOrder",
                column: "StatusOutboundOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDistrict_DistrictId",
                table: "SubDistrict",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_DistrictId",
                table: "Supplier",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ProvinceId",
                table: "Supplier",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_SubDistrictId",
                table: "Supplier",
                column: "SubDistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "OutboundItem");

            migrationBuilder.DropTable(
                name: "UserMangement");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ItemReceived");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "StatusInventory");

            migrationBuilder.DropTable(
                name: "OutboundOrder");

            migrationBuilder.DropTable(
                name: "InboundItem");

            migrationBuilder.DropTable(
                name: "ItemReceivedState");

            migrationBuilder.DropTable(
                name: "LocationCategory");

            migrationBuilder.DropTable(
                name: "StatusOutboundOrder");

            migrationBuilder.DropTable(
                name: "InboundOrder");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "OrderType");

            migrationBuilder.DropTable(
                name: "StatusInboundOrder");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "ItemCategory");

            migrationBuilder.DropTable(
                name: "QueueType");

            migrationBuilder.DropTable(
                name: "SubDistrict");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
