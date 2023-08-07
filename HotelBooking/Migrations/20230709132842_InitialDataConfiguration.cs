using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Description", "Name", "Stars" },
                values: new object[,]
                {
                    { new Guid("0c6cc6d4-3f8c-43d2-9591-230cb646aab9"), "Лесное убежище", "Поляна", 2 },
                    { new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), "Президентский отель Премиум-класса", "President Hotel", 5 },
                    { new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"), "Для настоящих патриотов", "Беларусь", 4 },
                    { new Guid("f934d940-f542-400b-8182-aea42a9b0773"), "Дефолтный 3-звездочный отель", "Турист", 3 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("3278235f-c470-4ba5-bc64-95a57739c8fc"), "Администратор программного средства", "ADMIN" },
                    { new Guid("a7369ffa-71c9-4238-947c-f62c2faa32ab"), "Пользователь системы бронирования", "USER" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("2d2205b1-2c38-4b92-a710-cf4861e1c6cf"), "Стандартный классический номер", "Стандарт" },
                    { new Guid("386c05e6-a4a5-451f-8363-246ff66367e9"), "Для полубогатых", "Полулюкс" },
                    { new Guid("628cb11b-e91c-4faf-b5d9-fc41d79496fa"), "Для богатых", "Люкс" },
                    { new Guid("984c5d2c-28f4-4ecc-ad45-d3c59d16fdbf"), "Для большого количества гостей", "Апартаменты" },
                    { new Guid("c7e74df3-94ad-4e25-b3c1-1a053ce1ff55"), "Для очень богатых", "Премиум" }
                });

            migrationBuilder.InsertData(
                table: "HotelPhotos",
                columns: new[] { "Id", "HotelId", "Path" },
                values: new object[,]
                {
                    { new Guid("04c07bdb-7007-44cb-93da-88cbc804eb42"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), "../../../Content/Images/Hotels/president-7.jpeg" },
                    { new Guid("0f8acada-d7bd-48dc-9bcb-dab862f9d7fb"), new Guid("f934d940-f542-400b-8182-aea42a9b0773"), "../../../Content/Images/Hotels/tourist-1.jpeg" },
                    { new Guid("119747c5-ddf0-4424-9fbd-9b5d72436961"), new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"), "../../../Content/Images/Hotels/belarus-6.jpeg" },
                    { new Guid("2582f52f-ee8e-4883-80c0-da66964834fc"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), "../../../Content/Images/Hotels/president-13.jpeg" },
                    { new Guid("3d342424-c0bb-430a-aaa5-e7f4f303218c"), new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"), "../../../Content/Images/Hotels/belarus-1.jpeg" },
                    { new Guid("44072262-47f2-4de3-9228-fd70b8dc6152"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), "../../../Content/Images/Hotels/president-14.jpeg" },
                    { new Guid("59458cf1-d34c-46ea-b723-02b805da8ea8"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), "../../../Content/Images/Hotels/president-2.jpeg" },
                    { new Guid("5d7dd90e-52eb-4252-9c98-85f04347fb77"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), "../../../Content/Images/Hotels/president-4.jpeg" },
                    { new Guid("74b7273d-2eb3-4e10-825d-0113584ca033"), new Guid("0c6cc6d4-3f8c-43d2-9591-230cb646aab9"), "../../../Content/Images/Hotels/polyana-3.jpeg" },
                    { new Guid("a061132d-d023-45dd-af0e-b64a4621367c"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), "../../../Content/Images/Hotels/president-5.jpeg" },
                    { new Guid("a1409c52-f913-484a-8818-50faf356e758"), new Guid("f934d940-f542-400b-8182-aea42a9b0773"), "../../../Content/Images/Hotels/tourist-2.jpeg" },
                    { new Guid("abafd7d4-6505-432a-87cd-5697610e80a3"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), "../../../Content/Images/Hotels/president-10.jpeg" },
                    { new Guid("b4df0d3f-ffea-4da9-a35c-0ea2a0a6c711"), new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"), "../../../Content/Images/Hotels/belarus-3.jpeg" },
                    { new Guid("b6f53299-7bb6-40e8-a199-a0ff89f80ed1"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), "../../../Content/Images/Hotels/president-11.jpeg" },
                    { new Guid("b79c720e-70cc-435f-a099-60fcfdef0ffd"), new Guid("0c6cc6d4-3f8c-43d2-9591-230cb646aab9"), "../../../Content/Images/Hotels/polyana-2.jpeg" },
                    { new Guid("b9c30434-24b1-431e-ab90-983e94304d5b"), new Guid("f934d940-f542-400b-8182-aea42a9b0773"), "../../../Content/Images/Hotels/tourist-3.jpeg" },
                    { new Guid("bdf29223-54a6-4bd5-bcdc-acf82f191d0a"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), "../../../Content/Images/Hotels/president-9.jpeg" },
                    { new Guid("bee00602-95cd-4b33-b481-4a0c96a59a4e"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), "../../../Content/Images/Hotels/president-8.jpeg" },
                    { new Guid("c1454523-6462-4ad3-ada9-586ac4cd15d4"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), "../../../Content/Images/Hotels/president-15.jpeg" },
                    { new Guid("c348d19a-e17a-4d27-8ff9-f6ab68130e3a"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), "../../../Content/Images/Hotels/president-1.jpeg" },
                    { new Guid("d63d7704-65aa-4ba3-bca1-daedf16c4769"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), "../../../Content/Images/Hotels/president-6.jpeg" },
                    { new Guid("d7493c84-ae52-489a-8b22-57263819df3b"), new Guid("f934d940-f542-400b-8182-aea42a9b0773"), "../../../Content/Images/Hotels/tourist-4.jpeg" },
                    { new Guid("df864455-1cb5-4055-80fe-02aa5a64d643"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), "../../../Content/Images/Hotels/president-3.jpeg" },
                    { new Guid("e6ed8378-aab5-4092-93e3-07d71d8011d3"), new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"), "../../../Content/Images/Hotels/belarus-2.jpeg" },
                    { new Guid("e82233dd-6b1e-4aac-b0f3-cc266c8b7e30"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), "../../../Content/Images/Hotels/president-12.jpeg" },
                    { new Guid("ebe39b18-6a9d-46d3-a46e-9edc75341e2f"), new Guid("0c6cc6d4-3f8c-43d2-9591-230cb646aab9"), "../../../Content/Images/Hotels/polyana-1.jpeg" },
                    { new Guid("f2bbfc71-b2ca-42b7-a010-8eb12b0cb70f"), new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"), "../../../Content/Images/Hotels/belarus-4.jpeg" },
                    { new Guid("f62ed813-562d-4e4f-95d1-ff385b11f016"), new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"), "../../../Content/Images/Hotels/belarus-5.jpeg" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "HotelId", "Price", "Quantity", "RoomTypeId", "SleepingPlaces" },
                values: new object[,]
                {
                    { new Guid("0bab8e32-e14b-4cd6-90ae-cf795fee80d8"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), 450.0, 6, new Guid("386c05e6-a4a5-451f-8363-246ff66367e9"), 2 },
                    { new Guid("1e7bbd59-e683-4700-b8f0-d279ba1304bb"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), 1020.0, 2, new Guid("c7e74df3-94ad-4e25-b3c1-1a053ce1ff55"), 4 },
                    { new Guid("4c1447d2-50f6-4397-9abb-b9b21e8661f2"), new Guid("f934d940-f542-400b-8182-aea42a9b0773"), 485.0, 14, new Guid("386c05e6-a4a5-451f-8363-246ff66367e9"), 6 },
                    { new Guid("59f51f88-0af4-4d98-882f-1ad1eccd8fd5"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), 678.0, 12, new Guid("628cb11b-e91c-4faf-b5d9-fc41d79496fa"), 2 },
                    { new Guid("684ff150-741e-4706-9306-07d4064efdb1"), new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"), 320.0, 14, new Guid("2d2205b1-2c38-4b92-a710-cf4861e1c6cf"), 2 },
                    { new Guid("7ab73b73-6712-4454-84d3-1694a61a22eb"), new Guid("0c6cc6d4-3f8c-43d2-9591-230cb646aab9"), 255.0, 10, new Guid("2d2205b1-2c38-4b92-a710-cf4861e1c6cf"), 3 },
                    { new Guid("7bd76d93-3167-49fe-98fc-7e4de14ac8b7"), new Guid("f934d940-f542-400b-8182-aea42a9b0773"), 310.0, 20, new Guid("2d2205b1-2c38-4b92-a710-cf4861e1c6cf"), 4 },
                    { new Guid("8c36266a-e422-4489-880a-c279f56340b2"), new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"), 400.0, 6, new Guid("628cb11b-e91c-4faf-b5d9-fc41d79496fa"), 2 },
                    { new Guid("96efe1d7-d219-4beb-a977-c5689fdfa062"), new Guid("0c6cc6d4-3f8c-43d2-9591-230cb646aab9"), 295.0, 6, new Guid("386c05e6-a4a5-451f-8363-246ff66367e9"), 4 },
                    { new Guid("f1960e67-d4c1-4b40-a454-f39fb3a655f2"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), 1045.0, 2, new Guid("984c5d2c-28f4-4ecc-ad45-d3c59d16fdbf"), 8 },
                    { new Guid("f8fb0b5c-d693-4e8c-934f-2ad79dba1bdc"), new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"), 365.0, 18, new Guid("2d2205b1-2c38-4b92-a710-cf4861e1c6cf"), 2 },
                    { new Guid("fccf41b7-b6a6-4f15-8a3b-fd50d67661db"), new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"), 370.0, 8, new Guid("386c05e6-a4a5-451f-8363-246ff66367e9"), 4 },
                    { new Guid("fe3b278a-3271-4a08-9b51-731d346fd8dc"), new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"), 860.0, 4, new Guid("c7e74df3-94ad-4e25-b3c1-1a053ce1ff55"), 4 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "RoleId" },
                values: new object[,]
                {
                    { new Guid("3a08ecca-7fbe-4886-ad58-61998c01c9e0"), "valdaitsevv@mail.ru", "Alexander", "Valdaitsev", "qweqwe", new Guid("a7369ffa-71c9-4238-947c-f62c2faa32ab") },
                    { new Guid("a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9"), "katie@mail.ru", "Katherine", "Vrublevskaya", "qweqwe", new Guid("a7369ffa-71c9-4238-947c-f62c2faa32ab") },
                    { new Guid("eb8fd43e-aa3d-4bf2-bfac-b70af06668e9"), "root@mail.ru", "Admin", "Root", "2233", new Guid("3278235f-c470-4ba5-bc64-95a57739c8fc") },
                    { new Guid("f94a3937-8935-48a4-81f3-4d6e33603c65"), "user@mail.ru", "Default", "User", "qweqwe", new Guid("a7369ffa-71c9-4238-947c-f62c2faa32ab") }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "DateEntry", "DateExit", "RoomId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0eb13a89-60ee-4d59-b991-908a4412bf0a"), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1e7bbd59-e683-4700-b8f0-d279ba1304bb"), new Guid("a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9") },
                    { new Guid("33f113d0-29af-4b2a-ac16-8a8e47aa4fcf"), new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("684ff150-741e-4706-9306-07d4064efdb1"), new Guid("f94a3937-8935-48a4-81f3-4d6e33603c65") },
                    { new Guid("6a5d35dc-682e-4d02-9e6b-a70550ef9061"), new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f1960e67-d4c1-4b40-a454-f39fb3a655f2"), new Guid("3a08ecca-7fbe-4886-ad58-61998c01c9e0") },
                    { new Guid("a9c9cf7b-f141-4a38-836c-da7c4183841d"), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7bd76d93-3167-49fe-98fc-7e4de14ac8b7"), new Guid("a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9") },
                    { new Guid("ba4a5cf4-fee9-4470-8de1-dd8333e4575d"), new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("96efe1d7-d219-4beb-a977-c5689fdfa062"), new Guid("f94a3937-8935-48a4-81f3-4d6e33603c65") },
                    { new Guid("d013f366-32d2-419b-b413-ee71f557435f"), new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f8fb0b5c-d693-4e8c-934f-2ad79dba1bdc"), new Guid("3a08ecca-7fbe-4886-ad58-61998c01c9e0") },
                    { new Guid("db277d82-62fd-49b8-b3ed-ad5976c1167c"), new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1e7bbd59-e683-4700-b8f0-d279ba1304bb"), new Guid("a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9") },
                    { new Guid("ff8f27ee-af5d-485f-9074-0598b9e73ac4"), new DateTime(2023, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4c1447d2-50f6-4397-9abb-b9b21e8661f2"), new Guid("3a08ecca-7fbe-4886-ad58-61998c01c9e0") }
                });

            migrationBuilder.InsertData(
                table: "RoomPhotos",
                columns: new[] { "Id", "Path", "RoomId" },
                values: new object[,]
                {
                    { new Guid("0bc90b3c-70bd-447e-9f59-6fa1b7f0170e"), "../../../Content/Images/Rooms/belarus-semilux-bathroom.jpeg", new Guid("fccf41b7-b6a6-4f15-8a3b-fd50d67661db") },
                    { new Guid("1099afd2-2a88-40de-b887-9ab9357efbea"), "../../../Content/Images/Rooms/president-lux-bed.jpeg", new Guid("59f51f88-0af4-4d98-882f-1ad1eccd8fd5") },
                    { new Guid("135c191d-e0c9-4f65-a872-7c9f5ce70ecd"), "../../../Content/Images/Rooms/president-apartments-bed.jpeg", new Guid("f1960e67-d4c1-4b40-a454-f39fb3a655f2") },
                    { new Guid("1b73584d-f785-4364-ba1c-41e45772e820"), "../../../Content/Images/Rooms/tourist-standart-bed.jpeg", new Guid("7bd76d93-3167-49fe-98fc-7e4de14ac8b7") },
                    { new Guid("2a6cb5f8-e341-4d81-ab56-a0e61d693caf"), "../../../Content/Images/Rooms/belarus-semilux-livingroom.jpeg", new Guid("fccf41b7-b6a6-4f15-8a3b-fd50d67661db") },
                    { new Guid("3edcb92d-7592-49ec-9c71-022c153a9c3d"), "../../../Content/Images/Rooms/president-semilux-bed.jpeg", new Guid("0bab8e32-e14b-4cd6-90ae-cf795fee80d8") },
                    { new Guid("513962ee-e04b-4fc6-8316-7d7c70b94b13"), "../../../Content/Images/Rooms/president-lux-livingroom.jpeg", new Guid("59f51f88-0af4-4d98-882f-1ad1eccd8fd5") },
                    { new Guid("52e0843f-8f2e-4a7c-9c3c-ed788b062613"), "../../../Content/Images/Rooms/president-semilux-livingroom.jpeg", new Guid("0bab8e32-e14b-4cd6-90ae-cf795fee80d8") },
                    { new Guid("660e5e4a-221f-4887-8b61-c8b57afb61b5"), "../../../Content/Images/Rooms/president-apartments-livingroom.jpeg", new Guid("f1960e67-d4c1-4b40-a454-f39fb3a655f2") },
                    { new Guid("67ed8c03-77aa-42fd-87c0-f3e8a93d2fc6"), "../../../Content/Images/Rooms/tourist-standart-bathroom.jpeg", new Guid("7bd76d93-3167-49fe-98fc-7e4de14ac8b7") },
                    { new Guid("8585a06c-1e9c-499d-a700-33bf69bdff3b"), "../../../Content/Images/Rooms/president-semilux-bathroom.jpeg", new Guid("0bab8e32-e14b-4cd6-90ae-cf795fee80d8") },
                    { new Guid("8e0294f6-8b34-4822-9f0a-b9ffc71eb193"), "../../../Content/Images/Rooms/president-standart-bathroom.jpeg", new Guid("f8fb0b5c-d693-4e8c-934f-2ad79dba1bdc") },
                    { new Guid("a5dbdace-9b51-4cff-8147-b86cbe8debd6"), "../../../Content/Images/Rooms/president-standart-bed.jpeg", new Guid("f8fb0b5c-d693-4e8c-934f-2ad79dba1bdc") },
                    { new Guid("f4f69c6f-2bf6-4e78-8c9b-21fa7902a701"), "../../../Content/Images/Rooms/president-apartments-kitchen.jpeg", new Guid("f1960e67-d4c1-4b40-a454-f39fb3a655f2") },
                    { new Guid("f63a8b8f-8b6b-407d-afa1-e632de572896"), "../../../Content/Images/Rooms/president-apartments-table.jpeg", new Guid("f1960e67-d4c1-4b40-a454-f39fb3a655f2") },
                    { new Guid("f701db8c-7575-40b9-a1f0-bc2af359a59e"), "../../../Content/Images/Rooms/belarus-semilux-bed.jpeg", new Guid("fccf41b7-b6a6-4f15-8a3b-fd50d67661db") },
                    { new Guid("f7fe0be5-a800-443d-93a2-bb90519c71be"), "../../../Content/Images/Rooms/president-semilux-livingroom-2.jpeg", new Guid("0bab8e32-e14b-4cd6-90ae-cf795fee80d8") },
                    { new Guid("ff522e71-70a3-41f2-b462-4485df71c03d"), "../../../Content/Images/Rooms/belarus-semilux-table.jpeg", new Guid("fccf41b7-b6a6-4f15-8a3b-fd50d67661db") }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "ReservationId", "TextNegative", "TextPositive" },
                values: new object[,]
                {
                    { new Guid("0c4e7c41-7dbe-475f-82ae-4000eb5c4e3d"), new Guid("d013f366-32d2-419b-b413-ee71f557435f"), "Я передумал мне ничего не понравилось", "Всё очень круто мне все понравилось" },
                    { new Guid("2b3b877e-b5c5-4ae8-b336-118492997598"), new Guid("ba4a5cf4-fee9-4470-8de1-dd8333e4575d"), "А девушка на ресепшене нет", "Консьерж был со мной вежлив" },
                    { new Guid("3217a198-5a8e-4818-9a7d-786043572775"), new Guid("0eb13a89-60ee-4d59-b991-908a4412bf0a"), "Не обнаружено", "Хороший отель интересные конкурсы" },
                    { new Guid("53032864-6d72-4367-b775-8915a17fb14b"), new Guid("db277d82-62fd-49b8-b3ed-ad5976c1167c"), "всё остальное.", "отсутствует." },
                    { new Guid("5f0c42ec-4f0b-4d1a-b4d9-8b04513b204f"), new Guid("33f113d0-29af-4b2a-ac16-8a8e47aa4fcf"), "Тумба, полка не понравились", "Напитки, завтрак в постель, ламинат" },
                    { new Guid("f0eefc9b-4cbe-4ee7-ae1e-37b335404b72"), new Guid("6a5d35dc-682e-4d02-9e6b-a70550ef9061"), "Перечислены выше", "Понравилось всё кроме отсутствия завтрака" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("0c4e7c41-7dbe-475f-82ae-4000eb5c4e3d"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("2b3b877e-b5c5-4ae8-b336-118492997598"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("3217a198-5a8e-4818-9a7d-786043572775"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("53032864-6d72-4367-b775-8915a17fb14b"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("5f0c42ec-4f0b-4d1a-b4d9-8b04513b204f"));

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: new Guid("f0eefc9b-4cbe-4ee7-ae1e-37b335404b72"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("04c07bdb-7007-44cb-93da-88cbc804eb42"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("0f8acada-d7bd-48dc-9bcb-dab862f9d7fb"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("119747c5-ddf0-4424-9fbd-9b5d72436961"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("2582f52f-ee8e-4883-80c0-da66964834fc"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("3d342424-c0bb-430a-aaa5-e7f4f303218c"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("44072262-47f2-4de3-9228-fd70b8dc6152"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("59458cf1-d34c-46ea-b723-02b805da8ea8"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("5d7dd90e-52eb-4252-9c98-85f04347fb77"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("74b7273d-2eb3-4e10-825d-0113584ca033"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("a061132d-d023-45dd-af0e-b64a4621367c"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("a1409c52-f913-484a-8818-50faf356e758"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("abafd7d4-6505-432a-87cd-5697610e80a3"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("b4df0d3f-ffea-4da9-a35c-0ea2a0a6c711"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("b6f53299-7bb6-40e8-a199-a0ff89f80ed1"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("b79c720e-70cc-435f-a099-60fcfdef0ffd"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("b9c30434-24b1-431e-ab90-983e94304d5b"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("bdf29223-54a6-4bd5-bcdc-acf82f191d0a"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("bee00602-95cd-4b33-b481-4a0c96a59a4e"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("c1454523-6462-4ad3-ada9-586ac4cd15d4"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("c348d19a-e17a-4d27-8ff9-f6ab68130e3a"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("d63d7704-65aa-4ba3-bca1-daedf16c4769"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("d7493c84-ae52-489a-8b22-57263819df3b"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("df864455-1cb5-4055-80fe-02aa5a64d643"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("e6ed8378-aab5-4092-93e3-07d71d8011d3"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("e82233dd-6b1e-4aac-b0f3-cc266c8b7e30"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("ebe39b18-6a9d-46d3-a46e-9edc75341e2f"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("f2bbfc71-b2ca-42b7-a010-8eb12b0cb70f"));

            migrationBuilder.DeleteData(
                table: "HotelPhotos",
                keyColumn: "Id",
                keyValue: new Guid("f62ed813-562d-4e4f-95d1-ff385b11f016"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("a9c9cf7b-f141-4a38-836c-da7c4183841d"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("ff8f27ee-af5d-485f-9074-0598b9e73ac4"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("0bc90b3c-70bd-447e-9f59-6fa1b7f0170e"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("1099afd2-2a88-40de-b887-9ab9357efbea"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("135c191d-e0c9-4f65-a872-7c9f5ce70ecd"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("1b73584d-f785-4364-ba1c-41e45772e820"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("2a6cb5f8-e341-4d81-ab56-a0e61d693caf"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("3edcb92d-7592-49ec-9c71-022c153a9c3d"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("513962ee-e04b-4fc6-8316-7d7c70b94b13"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("52e0843f-8f2e-4a7c-9c3c-ed788b062613"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("660e5e4a-221f-4887-8b61-c8b57afb61b5"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("67ed8c03-77aa-42fd-87c0-f3e8a93d2fc6"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("8585a06c-1e9c-499d-a700-33bf69bdff3b"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("8e0294f6-8b34-4822-9f0a-b9ffc71eb193"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("a5dbdace-9b51-4cff-8147-b86cbe8debd6"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("f4f69c6f-2bf6-4e78-8c9b-21fa7902a701"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("f63a8b8f-8b6b-407d-afa1-e632de572896"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("f701db8c-7575-40b9-a1f0-bc2af359a59e"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("f7fe0be5-a800-443d-93a2-bb90519c71be"));

            migrationBuilder.DeleteData(
                table: "RoomPhotos",
                keyColumn: "Id",
                keyValue: new Guid("ff522e71-70a3-41f2-b462-4485df71c03d"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("7ab73b73-6712-4454-84d3-1694a61a22eb"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("8c36266a-e422-4489-880a-c279f56340b2"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("fe3b278a-3271-4a08-9b51-731d346fd8dc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("eb8fd43e-aa3d-4bf2-bfac-b70af06668e9"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("0eb13a89-60ee-4d59-b991-908a4412bf0a"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("33f113d0-29af-4b2a-ac16-8a8e47aa4fcf"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("6a5d35dc-682e-4d02-9e6b-a70550ef9061"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("ba4a5cf4-fee9-4470-8de1-dd8333e4575d"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("d013f366-32d2-419b-b413-ee71f557435f"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("db277d82-62fd-49b8-b3ed-ad5976c1167c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3278235f-c470-4ba5-bc64-95a57739c8fc"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("0bab8e32-e14b-4cd6-90ae-cf795fee80d8"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("4c1447d2-50f6-4397-9abb-b9b21e8661f2"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("59f51f88-0af4-4d98-882f-1ad1eccd8fd5"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("7bd76d93-3167-49fe-98fc-7e4de14ac8b7"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("fccf41b7-b6a6-4f15-8a3b-fd50d67661db"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("f934d940-f542-400b-8182-aea42a9b0773"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("628cb11b-e91c-4faf-b5d9-fc41d79496fa"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1e7bbd59-e683-4700-b8f0-d279ba1304bb"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("684ff150-741e-4706-9306-07d4064efdb1"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("96efe1d7-d219-4beb-a977-c5689fdfa062"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("f1960e67-d4c1-4b40-a454-f39fb3a655f2"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("f8fb0b5c-d693-4e8c-934f-2ad79dba1bdc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a08ecca-7fbe-4886-ad58-61998c01c9e0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f94a3937-8935-48a4-81f3-4d6e33603c65"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("0c6cc6d4-3f8c-43d2-9591-230cb646aab9"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a7369ffa-71c9-4238-947c-f62c2faa32ab"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("2d2205b1-2c38-4b92-a710-cf4861e1c6cf"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("386c05e6-a4a5-451f-8363-246ff66367e9"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("984c5d2c-28f4-4ecc-ad45-d3c59d16fdbf"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("c7e74df3-94ad-4e25-b3c1-1a053ce1ff55"));
        }
    }
}
