USE [ServiceProvidingCompany]
GO
INSERT [dbo].[Bookings] ([Initial_Book_Id], [Consumer_Email], [Service_Id], [Address], [Landmark], [Phone], [Date], [PreferredTimeSlot1], [PreferredTimeSlot2], [Notes], [Payment], [Booking_Status]) VALUES (N'55382abe-7be3-4d55-bdde-77d1451e1e3a', N'consumer@ex.com', N'ACADV001', N'Sitapur', N'Lko', N'1234567890', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'05:00:00' AS Time), CAST(N'06:00:00' AS Time), N'!st booking', 1, N'Completed')
GO
INSERT [dbo].[Bookings] ([Initial_Book_Id], [Consumer_Email], [Service_Id], [Address], [Landmark], [Phone], [Date], [PreferredTimeSlot1], [PreferredTimeSlot2], [Notes], [Payment], [Booking_Status]) VALUES (N'84485a59-5f91-4bd7-8757-c9bfb0cb68f7', N'consumer@ex.com', N'ACADV001', N'Sitapur', N'Lko', N'1234567890', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'05:00:00' AS Time), CAST(N'06:00:00' AS Time), N'!st booking', 1, N'Accepted')
GO
INSERT [dbo].[Bookings] ([Initial_Book_Id], [Consumer_Email], [Service_Id], [Address], [Landmark], [Phone], [Date], [PreferredTimeSlot1], [PreferredTimeSlot2], [Notes], [Payment], [Booking_Status]) VALUES (N'BK101', N'c1@gmail.com', N'1015', N'Andheri East', N'Metro Station', N'900000001', CAST(N'2026-01-10T00:00:00.0000000' AS DateTime2), CAST(N'09:00:00' AS Time), CAST(N'11:00:00' AS Time), N'AC not cooling', 1, N'Accepted')
GO
INSERT [dbo].[Bookings] ([Initial_Book_Id], [Consumer_Email], [Service_Id], [Address], [Landmark], [Phone], [Date], [PreferredTimeSlot1], [PreferredTimeSlot2], [Notes], [Payment], [Booking_Status]) VALUES (N'BK102', N'c2@gmail.com', N'1016', N'Borivali', N'Mall Road', N'900000002', CAST(N'2026-01-11T00:00:00.0000000' AS DateTime2), CAST(N'11:00:00' AS Time), CAST(N'13:00:00' AS Time), N'Tap leakage', 0, N'Accepted')
GO
INSERT [dbo].[Bookings] ([Initial_Book_Id], [Consumer_Email], [Service_Id], [Address], [Landmark], [Phone], [Date], [PreferredTimeSlot1], [PreferredTimeSlot2], [Notes], [Payment], [Booking_Status]) VALUES (N'BK103', N'c3@gmail.com', N'1017', N'Whitefield', N'IT Park', N'900000003', CAST(N'2026-01-12T00:00:00.0000000' AS DateTime2), CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), N'Full cleaning', 2, N'Accepted')
GO
INSERT [dbo].[Bookings] ([Initial_Book_Id], [Consumer_Email], [Service_Id], [Address], [Landmark], [Phone], [Date], [PreferredTimeSlot1], [PreferredTimeSlot2], [Notes], [Payment], [Booking_Status]) VALUES (N'BK104', N'c4@gmail.com', N'1018', N'Dwarka', N'Sector 5', N'900000004', CAST(N'2026-01-13T00:00:00.0000000' AS DateTime2), CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), N'Switch issue', 2, N'Accepted')
GO
INSERT [dbo].[Bookings] ([Initial_Book_Id], [Consumer_Email], [Service_Id], [Address], [Landmark], [Phone], [Date], [PreferredTimeSlot1], [PreferredTimeSlot2], [Notes], [Payment], [Booking_Status]) VALUES (N'BKG-001', N'alice@example.com', N'ACADV001', N'12 Green Street', N'Near Park', N'9876543210', CAST(N'2026-01-05T00:00:00.0000000' AS DateTime2), CAST(N'10:00:00' AS Time), CAST(N'14:00:00' AS Time), N'AC not cooling', 1, N'Completed')
GO
INSERT [dbo].[Bookings] ([Initial_Book_Id], [Consumer_Email], [Service_Id], [Address], [Landmark], [Phone], [Date], [PreferredTimeSlot1], [PreferredTimeSlot2], [Notes], [Payment], [Booking_Status]) VALUES (N'BKG-002', N'bob@example.com', N'ACADV001', N'45 Blue Avenue', N'Opp. Mall', N'8765432109', CAST(N'2026-01-06T00:00:00.0000000' AS DateTime2), CAST(N'09:00:00' AS Time), CAST(N'13:00:00' AS Time), N'AC leaking water', 2, N'Completed')
GO
INSERT [dbo].[Bookings] ([Initial_Book_Id], [Consumer_Email], [Service_Id], [Address], [Landmark], [Phone], [Date], [PreferredTimeSlot1], [PreferredTimeSlot2], [Notes], [Payment], [Booking_Status]) VALUES (N'BKG-003', N'charlie@example.com', N'ACADV001', N'78 Red Road', N'Near School', N'7654321098', CAST(N'2026-01-07T00:00:00.0000000' AS DateTime2), CAST(N'11:00:00' AS Time), CAST(N'15:00:00' AS Time), N'AC not turning on', 3, N'Completed')
GO
INSERT [dbo].[Bookings] ([Initial_Book_Id], [Consumer_Email], [Service_Id], [Address], [Landmark], [Phone], [Date], [PreferredTimeSlot1], [PreferredTimeSlot2], [Notes], [Payment], [Booking_Status]) VALUES (N'BKG-005', N'eve@example.com', N'ACADV001', N'56 Orange Street', N'Near Bank', N'5432109876', CAST(N'2026-01-09T00:00:00.0000000' AS DateTime2), CAST(N'12:00:00' AS Time), CAST(N'16:00:00' AS Time), N'AC gas refill', 2, N'Completed')
GO
INSERT [dbo].[Bookings] ([Initial_Book_Id], [Consumer_Email], [Service_Id], [Address], [Landmark], [Phone], [Date], [PreferredTimeSlot1], [PreferredTimeSlot2], [Notes], [Payment], [Booking_Status]) VALUES (N'BKG-006', N'frank@example.com', N'ACADV001', N'89 Purple Road', N'Opp. Hospital', N'4321098765', CAST(N'2026-01-10T00:00:00.0000000' AS DateTime2), CAST(N'09:30:00' AS Time), CAST(N'13:30:00' AS Time), N'AC service and cleaning', 3, N'Completed')
GO
INSERT [dbo].[Bookings] ([Initial_Book_Id], [Consumer_Email], [Service_Id], [Address], [Landmark], [Phone], [Date], [PreferredTimeSlot1], [PreferredTimeSlot2], [Notes], [Payment], [Booking_Status]) VALUES (N'BKG-007', N'grace@example.com', N'ACADV001', N'34 White Lane', N'Next to School', N'3210987654', CAST(N'2026-01-11T00:00:00.0000000' AS DateTime2), CAST(N'11:00:00' AS Time), CAST(N'15:00:00' AS Time), N'AC compressor issue', 1, N'Completed')
GO
INSERT [dbo].[Bookings] ([Initial_Book_Id], [Consumer_Email], [Service_Id], [Address], [Landmark], [Phone], [Date], [PreferredTimeSlot1], [PreferredTimeSlot2], [Notes], [Payment], [Booking_Status]) VALUES (N'BKG-008', N'henry@example.com', N'ACADV001', N'67 Black Street', N'Near Mall', N'2109876543', CAST(N'2026-01-12T00:00:00.0000000' AS DateTime2), CAST(N'10:00:00' AS Time), CAST(N'14:00:00' AS Time), N'AC filter replacement', 2, N'Completed')
GO
INSERT [dbo].[Bookings] ([Initial_Book_Id], [Consumer_Email], [Service_Id], [Address], [Landmark], [Phone], [Date], [PreferredTimeSlot1], [PreferredTimeSlot2], [Notes], [Payment], [Booking_Status]) VALUES (N'BKG-009', N'irene@example.com', N'ACADV001', N'90 Brown Avenue', N'Opp. Park', N'1098765432', CAST(N'2026-01-13T00:00:00.0000000' AS DateTime2), CAST(N'09:00:00' AS Time), CAST(N'13:00:00' AS Time), N'AC not cooling properly', 3, N'Completed')
GO
INSERT [dbo].[Bookings] ([Initial_Book_Id], [Consumer_Email], [Service_Id], [Address], [Landmark], [Phone], [Date], [PreferredTimeSlot1], [PreferredTimeSlot2], [Notes], [Payment], [Booking_Status]) VALUES (N'f87ef66c-a273-47fe-bae3-0f5961426704', N'consumer@ex.com', N'ACADV001', N'Sitapur', N'Lko', N'1234567890', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'05:00:00' AS Time), CAST(N'06:00:00' AS Time), N'!st booking', 1, N'Rejected')
GO
INSERT [dbo].[CategoryTables] ([Category_Id], [Category_name], [Category_images]) VALUES (N'1', N'Plumber', N'https://res.cloudinary.com/dmk0npdfp/image/upload/v1767325742/plumber_fd0w4j.jpg')
GO
INSERT [dbo].[CategoryTables] ([Category_Id], [Category_name], [Category_images]) VALUES (N'2', N'Electrician', N'https://res.cloudinary.com/dmk0npdfp/image/upload/v1767325741/Electrician_l99b2y.webp')
GO
INSERT [dbo].[CategoryTables] ([Category_Id], [Category_name], [Category_images]) VALUES (N'3', N'Carpenter', N'https://res.cloudinary.com/dmk0npdfp/image/upload/v1767326053/carpenter-putting-wooden-plank-pressing-tool-handicraft-concept-high-quality-photo-278892357_fhjnch.webp')
GO
INSERT [dbo].[CategoryTables] ([Category_Id], [Category_name], [Category_images]) VALUES (N'4', N'Cleaning', N'https://res.cloudinary.com/dmk0npdfp/image/upload/v1767326053/360_F_345737231_E7su9pVQi2HbCXxUJa0BwI7ByScDdixi_hnzdui.jpg')
GO
INSERT [dbo].[CategoryTables] ([Category_Id], [Category_name], [Category_images]) VALUES (N'5', N'AC Repair', N'https://res.cloudinary.com/dmk0npdfp/image/upload/v1767321788/acrepainr_othloh.jpg')
GO
INSERT [dbo].[CategoryTables] ([Category_Id], [Category_name], [Category_images]) VALUES (N'6', N'Painter', N'https://res.cloudinary.com/dmk0npdfp/image/upload/v1767326053/wallpainter_ajqtef.jpg')
GO
INSERT [dbo].[ContactInfos] ([Contact_Info_Id], [Content_Heading], [Content], [Url], [Contact_Info_Category]) VALUES (N'CI501', N'Address', N'123 ServiceProvidingCompany Lane, Lakhimpur, India', N'<iframe 
    src="https://www.google.com/maps?q=123%20ServiceProvidingCompany%20Lane,%20Lakhimpur,%20India&output=embed"
    width="100%" 
    height="120" 
    style="border:0;" 
    allowfullscreen 
    loading="lazy">
</iframe>', N'Contact')
GO
INSERT [dbo].[ContactInfos] ([Contact_Info_Id], [Content_Heading], [Content], [Url], [Contact_Info_Category]) VALUES (N'CI502', N'Email', N'support@ServiceProvidingCompany.com', NULL, N'Contact')
GO
INSERT [dbo].[ContactInfos] ([Contact_Info_Id], [Content_Heading], [Content], [Url], [Contact_Info_Category]) VALUES (N'CI503', N'Phone', N'+91 9876543210', NULL, N'Contact')
GO
INSERT [dbo].[ContactInfos] ([Contact_Info_Id], [Content_Heading], [Content], [Url], [Contact_Info_Category]) VALUES (N'CI504', N'Facebook', NULL, N'<a href="#"><iframe src="https://cdn.jsdelivr.net/npm/simple-icons@v11/icons/facebook.svg" scrolling="no"></iframe></a>', N'Social')
GO
INSERT [dbo].[ContactInfos] ([Contact_Info_Id], [Content_Heading], [Content], [Url], [Contact_Info_Category]) VALUES (N'CI505', N'Twitter', NULL, N'<iframe src="https://cdn.jsdelivr.net/npm/simple-icons@v11/icons/x.svg" scrolling="no"></iframe>', N'Social')
GO
INSERT [dbo].[ContactInfos] ([Contact_Info_Id], [Content_Heading], [Content], [Url], [Contact_Info_Category]) VALUES (N'CI506', N'Instagram', NULL, N'<iframe src="https://cdn.jsdelivr.net/npm/simple-icons@v11/icons/instagram.svg" scrolling="no"></iframe>', N'Social')
GO
INSERT [dbo].[ContactInfos] ([Contact_Info_Id], [Content_Heading], [Content], [Url], [Contact_Info_Category]) VALUES (N'CI507', N'LinkedIn', NULL, N'<iframe src="https://cdn.jsdelivr.net/npm/simple-icons@v11/icons/linkedin.svg" scrolling="no"></iframe>', N'Social')
GO
INSERT [dbo].[QueryModels] ([Query_Id], [Full_Name], [Email], [Message]) VALUES (N'bb50959c-a884-43b4-a13b-46bf14e4116c', N'Consumer', N'Consumer@ex.com', N'Checking working or not')
GO
INSERT [dbo].[ServiceBookings] ([Booking_Id], [Initial_Book_Id], [Consumer_Email], [Provider_Email], [Service_Id], [Service_Category], [Rating], [Customer_Feedback], [Booking_Completed_Date]) VALUES (N'673c87ed-8176-4937-91fd-c90798ebac71', N'55382abe-7be3-4d55-bdde-77d1451e1e3a', N'consumer@ex.com', N'provider@ex.com', N'ACADV001', N'AC Repair', NULL, NULL, N'2026-01-11 20:37:35')
GO
INSERT [dbo].[ServiceBookings] ([Booking_Id], [Initial_Book_Id], [Consumer_Email], [Provider_Email], [Service_Id], [Service_Category], [Rating], [Customer_Feedback], [Booking_Completed_Date]) VALUES (N'SB-001', N'BKG-001', N'alice@example.com', N'provider@ex.com', N'ACADV001', N'AC Repair', 5, N'Excellent service!', N'2026-01-05')
GO
INSERT [dbo].[ServiceBookings] ([Booking_Id], [Initial_Book_Id], [Consumer_Email], [Provider_Email], [Service_Id], [Service_Category], [Rating], [Customer_Feedback], [Booking_Completed_Date]) VALUES (N'SB-002', N'BKG-002', N'bob@example.com', N'provider@ex.com', N'ACADV001', N'AC Repair', 4, N'Quick and professional', N'2026-01-06')
GO
INSERT [dbo].[ServiceBookings] ([Booking_Id], [Initial_Book_Id], [Consumer_Email], [Provider_Email], [Service_Id], [Service_Category], [Rating], [Customer_Feedback], [Booking_Completed_Date]) VALUES (N'SB-003', N'BKG-003', N'charlie@example.com', N'provider@ex.com', N'ACADV001', N'AC Repair', 5, N'Very satisfied', N'2026-01-07')
GO
INSERT [dbo].[ServiceBookings] ([Booking_Id], [Initial_Book_Id], [Consumer_Email], [Provider_Email], [Service_Id], [Service_Category], [Rating], [Customer_Feedback], [Booking_Completed_Date]) VALUES (N'SB-005', N'BKG-005', N'eve@example.com', N'provider@ex.com', N'ACADV001', N'AC Repair', 5, N'Perfect work', N'2026-01-09')
GO
INSERT [dbo].[ServiceBookings] ([Booking_Id], [Initial_Book_Id], [Consumer_Email], [Provider_Email], [Service_Id], [Service_Category], [Rating], [Customer_Feedback], [Booking_Completed_Date]) VALUES (N'SB-006', N'BKG-006', N'frank@example.com', N'provider@ex.com', N'ACADV001', N'AC Repair', 4, N'Good job', N'2026-01-10')
GO
INSERT [dbo].[ServiceBookings] ([Booking_Id], [Initial_Book_Id], [Consumer_Email], [Provider_Email], [Service_Id], [Service_Category], [Rating], [Customer_Feedback], [Booking_Completed_Date]) VALUES (N'SB-007', N'BKG-007', N'grace@example.com', N'provider@ex.com', N'ACADV001', N'AC Repair', 5, N'Highly recommended', N'2026-01-11')
GO
INSERT [dbo].[ServiceBookings] ([Booking_Id], [Initial_Book_Id], [Consumer_Email], [Provider_Email], [Service_Id], [Service_Category], [Rating], [Customer_Feedback], [Booking_Completed_Date]) VALUES (N'SB-008', N'BKG-008', N'henry@example.com', N'provider@ex.com', N'ACADV001', N'AC Repair', 3, N'Satisfactory', N'2026-01-12')
GO
INSERT [dbo].[ServiceBookings] ([Booking_Id], [Initial_Book_Id], [Consumer_Email], [Provider_Email], [Service_Id], [Service_Category], [Rating], [Customer_Feedback], [Booking_Completed_Date]) VALUES (N'SB-009', N'BKG-009', N'irene@example.com', N'provider@ex.com', N'ACADV001', N'AC Repair', 4, N'Good cleaning', N'2026-01-13')
GO
INSERT [dbo].[ServiceInfos] ([Service_Id], [ServiceName], [Description], [Pricing], [Duration], [Category], [ImagePath], [WorkingHoursStart], [WorkingHoursEnd], [WeeklySchedule], [BlockDates], [TimeSlots], [City], [PinCode], [Radius], [Addresses], [FullName], [Phone], [Email], [BusinessName], [VerificationDocsPath], [NotifyEmail], [NotifySms], [NotifyApp]) VALUES (N'1016', N'Plumber Visit', N'Leak & tap fixing', N'399', N'45', N'Plumber', N'https://trusteyman.com/wp-content/uploads/2019/02/how-does-plumbing-work-e1548696261445.jpeg', CAST(N'09:00:00' AS Time), CAST(N'17:00:00' AS Time), N'Mon-Fri', NULL, N'09-11,11-13,14-16', N'Mumbai', N'400002', 10, N'Borivali', N'Suresh Patil', N'9876500001', N'suresh@gmail.com', N'Fast Plumbing', N'docs/pl1.pdf', 1, 1, 1)
GO
INSERT [dbo].[ServiceInfos] ([Service_Id], [ServiceName], [Description], [Pricing], [Duration], [Category], [ImagePath], [WorkingHoursStart], [WorkingHoursEnd], [WeeklySchedule], [BlockDates], [TimeSlots], [City], [PinCode], [Radius], [Addresses], [FullName], [Phone], [Email], [BusinessName], [VerificationDocsPath], [NotifyEmail], [NotifySms], [NotifyApp]) VALUES (N'1017', N'Home Cleaning', N'Full home cleaning', N'699', N'120', N'Cleaning', N'https://www.rd.com/wp-content/uploads/2023/07/GettyImages-1316432905-e1689268716150.jpg', CAST(N'08:00:00' AS Time), CAST(N'16:00:00' AS Time), N'Tue-Sun', NULL, N'08-10,10-12,13-15', N'Bangalore', N'560001', 12, N'Whitefield', N'Anita Rao', N'9876500002', N'anita@gmail.com', N'Spark Clean', N'docs/cl1.pdf', 1, 1, 1)
GO
INSERT [dbo].[ServiceInfos] ([Service_Id], [ServiceName], [Description], [Pricing], [Duration], [Category], [ImagePath], [WorkingHoursStart], [WorkingHoursEnd], [WeeklySchedule], [BlockDates], [TimeSlots], [City], [PinCode], [Radius], [Addresses], [FullName], [Phone], [Email], [BusinessName], [VerificationDocsPath], [NotifyEmail], [NotifySms], [NotifyApp]) VALUES (N'1018', N'Electrician Fix', N'Switch & wiring', N'449', N'60', N'Electrician', N'https://wallpapers.com/images/hd/electrician-checking-voltmeter-zpluh1tf2du87juu.jpg', CAST(N'10:00:00' AS Time), CAST(N'18:00:00' AS Time), N'Mon-Sat', NULL, N'10-12,12-14,15-17', N'Delhi', N'110001', 15, N'Dwarka', N'Manoj Jain', N'9876500003', N'manoj@gmail.com', N'PowerFix', N'docs/el1.pdf', 1, 0, 1)
GO
INSERT [dbo].[ServiceInfos] ([Service_Id], [ServiceName], [Description], [Pricing], [Duration], [Category], [ImagePath], [WorkingHoursStart], [WorkingHoursEnd], [WeeklySchedule], [BlockDates], [TimeSlots], [City], [PinCode], [Radius], [Addresses], [FullName], [Phone], [Email], [BusinessName], [VerificationDocsPath], [NotifyEmail], [NotifySms], [NotifyApp]) VALUES (N'1019', N'AC Advanced Check', N'Full AC servicing and gas refill', N'899', N'90', N'AC Repair', N'https://koala.sh/api/image/v2-96gzk-1vb1u.jpg', CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'Mon-Sat', NULL, N'09-11,11-13,14-16', N'Mumbai', N'400003', 15, N'Andheri West', N'Rohit Verma', N'9876543211', N'provider@ex.com', N'CoolAir Services', N'docs/ac2.pdf', 1, 1, 1)
GO
INSERT [dbo].[ServiceInfos] ([Service_Id], [ServiceName], [Description], [Pricing], [Duration], [Category], [ImagePath], [WorkingHoursStart], [WorkingHoursEnd], [WeeklySchedule], [BlockDates], [TimeSlots], [City], [PinCode], [Radius], [Addresses], [FullName], [Phone], [Email], [BusinessName], [VerificationDocsPath], [NotifyEmail], [NotifySms], [NotifyApp]) VALUES (N'ACADV001', N'AC Advance Service', N'Complete AC advance servicing including deep cleaning, gas check, and performance tuning.', N'1499', N'90 Minutes', N'AC Repair', N'https://koala.sh/api/image/v2-96gzk-1vb1u.jpg', CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'Mon-Sat', NULL, N'09:00-11:00,11:00-01:00,02:00-04:00,04:00-06:00', N'Lakhimpur', N'262701', 15, N'Home Service at Customer Location', N'AC Service Provider', N'9876543210', N'provider@ex.com', N'CoolAir Services', N'docs/pl58.pdf', 1, 1, 1)
GO
INSERT [dbo].[SignUps] ([Email], [Full_Name], [Phone_Number], [User_Role], [Password]) VALUES (N'alice@example.com', N'Alice', N'9876543210', N'Consumer', N'AQAAAAIAAYagAAAAEK4csbYasEvVZyS0nIDvpJuAbNXlwVGJict6m3oMDCMKWx1Y/rXgQRLXNqIy9PNa3w==')
GO
INSERT [dbo].[SignUps] ([Email], [Full_Name], [Phone_Number], [User_Role], [Password]) VALUES (N'bob@example.com', N'Bob', N'8765432109', N'Consumer', N'AQAAAAIAAYagAAAAEK4csbYasEvVZyS0nIDvpJuAbNXlwVGJict6m3oMDCMKWx1Y/rXgQRLXNqIy9PNa3w==')
GO
INSERT [dbo].[SignUps] ([Email], [Full_Name], [Phone_Number], [User_Role], [Password]) VALUES (N'charlie@example.com', N'Charlie', N'7654321098', N'Consumer', N'AQAAAAIAAYagAAAAEK4csbYasEvVZyS0nIDvpJuAbNXlwVGJict6m3oMDCMKWx1Y/rXgQRLXNqIy9PNa3w==')
GO
INSERT [dbo].[SignUps] ([Email], [Full_Name], [Phone_Number], [User_Role], [Password]) VALUES (N'consumer@ex.com', N'consumer', N'1234567890', N'Consumer', N'AQAAAAIAAYagAAAAEK4csbYasEvVZyS0nIDvpJuAbNXlwVGJict6m3oMDCMKWx1Y/rXgQRLXNqIy9PNa3w==')
GO
INSERT [dbo].[SignUps] ([Email], [Full_Name], [Phone_Number], [User_Role], [Password]) VALUES (N'eve@example.com', N'Eve', N'5432109876', N'Consumer', N'AQAAAAIAAYagAAAAEK4csbYasEvVZyS0nIDvpJuAbNXlwVGJict6m3oMDCMKWx1Y/rXgQRLXNqIy9PNa3w==')
GO
INSERT [dbo].[SignUps] ([Email], [Full_Name], [Phone_Number], [User_Role], [Password]) VALUES (N'frank@example.com', N'Frank', N'4321098765', N'Consumer', N'AQAAAAIAAYagAAAAEK4csbYasEvVZyS0nIDvpJuAbNXlwVGJict6m3oMDCMKWx1Y/rXgQRLXNqIy9PNa3w==')
GO
INSERT [dbo].[SignUps] ([Email], [Full_Name], [Phone_Number], [User_Role], [Password]) VALUES (N'grace@example.com', N'Grace', N'3210987654', N'Consumer', N'AQAAAAIAAYagAAAAEK4csbYasEvVZyS0nIDvpJuAbNXlwVGJict6m3oMDCMKWx1Y/rXgQRLXNqIy9PNa3w==')
GO
INSERT [dbo].[SignUps] ([Email], [Full_Name], [Phone_Number], [User_Role], [Password]) VALUES (N'henry@example.com', N'Henry', N'2109876543', N'Consumer', N'AQAAAAIAAYagAAAAEK4csbYasEvVZyS0nIDvpJuAbNXlwVGJict6m3oMDCMKWx1Y/rXgQRLXNqIy9PNa3w==')
GO
INSERT [dbo].[SignUps] ([Email], [Full_Name], [Phone_Number], [User_Role], [Password]) VALUES (N'irene@example.com', N'Irene', N'1098765432', N'Consumer', N'AQAAAAIAAYagAAAAEK4csbYasEvVZyS0nIDvpJuAbNXlwVGJict6m3oMDCMKWx1Y/rXgQRLXNqIy9PNa3w==')
GO
INSERT [dbo].[SignUps] ([Email], [Full_Name], [Phone_Number], [User_Role], [Password]) VALUES (N'provider@ex.com', N'provider', N'1234567890', N'Service Provider', N'AQAAAAIAAYagAAAAEIzOWjiqa0vZ2bKG9DujIteFiu602o5g5qFRoWio3eb1CzjeaRpcoCo28ENQcEJqww==')
GO
