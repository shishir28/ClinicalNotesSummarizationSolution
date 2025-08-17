-- Comprehensive Clinical Notes Database Seed Data
-- This script creates realistic medical data for testing and development
-- Includes 100+ patients, diverse medical providers, and extensive medical conditions

-- Clear existing data (in proper order due to foreign key constraints)
DELETE FROM "Allergies";
DELETE FROM "Appointments";
DELETE FROM "ClinicalNotes";
DELETE FROM "Diagnoses";
DELETE FROM "MedicalConditions";
DELETE FROM "Medications";
DELETE FROM "Patients";
DELETE FROM "MedicalProviders";

-- Insert Medical Providers first (they don't depend on other tables)
INSERT INTO "MedicalProviders" ("Id", "Name", "Specialty", "LicenseNumber") VALUES
('11111111-1111-1111-1111-111111111111', 'Dr. Sarah Johnson', 'Internal Medicine', 'MD-12345-NY'),
('22222222-2222-2222-2222-222222222222', 'Dr. Michael Chen', 'Cardiology', 'MD-23456-CA'),
('33333333-3333-3333-3333-333333333333', 'Dr. Emily Rodriguez', 'Endocrinology', 'MD-34567-TX'),
('44444444-4444-4444-4444-444444444444', 'Dr. James Wilson', 'Orthopedics', 'MD-45678-FL'),
('55555555-5555-5555-5555-555555555555', 'Dr. Lisa Thompson', 'Psychiatry', 'MD-56789-WA'),
('66666666-6666-6666-6666-666666666666', 'Dr. Robert Kim', 'Dermatology', 'MD-67890-IL'),
('77777777-7777-7777-7777-777777777777', 'Dr. Maria Garcia', 'Pulmonology', 'MD-78901-AZ'),
('88888888-8888-8888-8888-888888888888', 'Dr. David Brown', 'Nephrology', 'MD-89012-OH'),
('99999999-9999-9999-9999-999999999999', 'Dr. Amanda Lee', 'Oncology', 'MD-90123-CA'),
('aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01', 'Dr. Christopher Taylor', 'Neurology', 'MD-01234-TX'),
('bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbb01', 'Dr. Jessica Martinez', 'Gastroenterology', 'MD-12340-FL'),
('cccccccc-cccc-cccc-cccc-cccccccccc01', 'Dr. Daniel Anderson', 'Rheumatology', 'MD-23401-NY'),
('dddddddd-dddd-dddd-dddd-dddddddddd01', 'Dr. Patricia White', 'Infectious Disease', 'MD-34012-WA'),
('eeeeeeee-eeee-eeee-eeee-eeeeeeeeee01', 'Dr. Kevin Harris', 'Emergency Medicine', 'MD-40123-IL'),
('ffffffff-ffff-ffff-ffff-ffffffffff01', 'Dr. Michelle Clark', 'Family Medicine', 'MD-01235-AZ'),
('12345678-1234-1234-1234-123456789012', 'Dr. Thomas Lewis', 'Urology', 'MD-51234-OH'),
('23456789-2345-2345-2345-234567890123', 'Dr. Rachel Walker', 'Obstetrics & Gynecology', 'MD-61234-CA'),
('34567890-3456-3456-3456-345678901234', 'Dr. Steven Hall', 'Ophthalmology', 'MD-71234-TX'),
('45678901-4567-4567-4567-456789012345', 'Dr. Angela Young', 'Anesthesiology', 'MD-81234-FL'),
('56789012-5678-5678-5678-567890123456', 'Dr. Mark King', 'Radiology', 'MD-91234-NY');

-- Insert 100+ Patients with diverse demographics
INSERT INTO "Patients" ("Id", "FirstName", "LastName", "DateOfBirth", "Gender", "PhoneNumber", "Email", "Address", "CreatedAt", "UpdatedAt") VALUES
-- Original 6 patients
('aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'John', 'Anderson', '1975-03-15T00:00:00+00:00', 'Male', '555-0101', 'john.anderson@email.com', '123 Main St, New York, NY 10001', NOW(), NOW()),
('bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'Mary', 'Williams', '1982-07-22T00:00:00+00:00', 'Female', '555-0102', 'mary.williams@email.com', '456 Oak Ave, Los Angeles, CA 90210', NOW(), NOW()),
('cccccccc-cccc-cccc-cccc-cccccccccccc', 'Robert', 'Davis', '1968-12-03T00:00:00+00:00', 'Male', '555-0103', 'robert.davis@email.com', '789 Pine St, Chicago, IL 60601', NOW(), NOW()),
('dddddddd-dddd-dddd-dddd-dddddddddddd', 'Jennifer', 'Miller', '1990-09-18T00:00:00+00:00', 'Female', '555-0104', 'jennifer.miller@email.com', '321 Elm Dr, Houston, TX 77001', NOW(), NOW()),
('eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', 'Michael', 'Wilson', '1955-11-08T00:00:00+00:00', 'Male', '555-0105', 'michael.wilson@email.com', '654 Maple Ln, Phoenix, AZ 85001', NOW(), NOW()),
('ffffffff-ffff-ffff-ffff-ffffffffffff', 'Linda', 'Moore', '1988-04-30T00:00:00+00:00', 'Female', '555-0106', 'linda.moore@email.com', '987 Cedar St, Philadelphia, PA 19101', NOW(), NOW()),

-- Additional 94+ patients for comprehensive testing
('10000000-0000-0000-0000-000000000001', 'James', 'Smith', '1965-01-10T00:00:00+00:00', 'Male', '555-0107', 'james.smith@email.com', '100 First St, Boston, MA 02101', NOW(), NOW()),
('10000000-0000-0000-0000-000000000002', 'Patricia', 'Johnson', '1978-05-15T00:00:00+00:00', 'Female', '555-0108', 'patricia.johnson@email.com', '200 Second St, Seattle, WA 98101', NOW(), NOW()),
('10000000-0000-0000-0000-000000000003', 'Christopher', 'Brown', '1992-08-22T00:00:00+00:00', 'Male', '555-0109', 'christopher.brown@email.com', '300 Third Ave, Denver, CO 80201', NOW(), NOW()),
('10000000-0000-0000-0000-000000000004', 'Amanda', 'Jones', '1985-12-05T00:00:00+00:00', 'Female', '555-0110', 'amanda.jones@email.com', '400 Fourth St, Miami, FL 33101', NOW(), NOW()),
('10000000-0000-0000-0000-000000000005', 'David', 'Garcia', '1970-03-18T00:00:00+00:00', 'Male', '555-0111', 'david.garcia@email.com', '500 Fifth Ave, San Antonio, TX 78201', NOW(), NOW()),
('10000000-0000-0000-0000-000000000006', 'Sarah', 'Martinez', '1995-07-25T00:00:00+00:00', 'Female', '555-0112', 'sarah.martinez@email.com', '600 Sixth St, Portland, OR 97201', NOW(), NOW()),
('10000000-0000-0000-0000-000000000007', 'Daniel', 'Rodriguez', '1963-11-12T00:00:00+00:00', 'Male', '555-0113', 'daniel.rodriguez@email.com', '700 Seventh Ave, Las Vegas, NV 89101', NOW(), NOW()),
('10000000-0000-0000-0000-000000000008', 'Jessica', 'Lopez', '1987-02-28T00:00:00+00:00', 'Female', '555-0114', 'jessica.lopez@email.com', '800 Eighth St, Detroit, MI 48201', NOW(), NOW()),
('10000000-0000-0000-0000-000000000009', 'Matthew', 'Gonzalez', '1973-06-14T00:00:00+00:00', 'Male', '555-0115', 'matthew.gonzalez@email.com', '900 Ninth Ave, Nashville, TN 37201', NOW(), NOW()),
('10000000-0000-0000-0000-000000000010', 'Ashley', 'Wilson', '1991-10-03T00:00:00+00:00', 'Female', '555-0116', 'ashley.wilson@email.com', '1000 Tenth St, Atlanta, GA 30301', NOW(), NOW()),
('10000000-0000-0000-0000-000000000011', 'Anthony', 'Anderson', '1959-04-20T00:00:00+00:00', 'Male', '555-0117', 'anthony.anderson@email.com', '1100 Eleventh Ave, Baltimore, MD 21201', NOW(), NOW()),
('10000000-0000-0000-0000-000000000012', 'Emily', 'Thomas', '1986-08-17T00:00:00+00:00', 'Female', '555-0118', 'emily.thomas@email.com', '1200 Twelfth St, Milwaukee, WI 53201', NOW(), NOW()),
('10000000-0000-0000-0000-000000000013', 'Joshua', 'Taylor', '1994-01-09T00:00:00+00:00', 'Male', '555-0119', 'joshua.taylor@email.com', '1300 Thirteenth Ave, Minneapolis, MN 55401', NOW(), NOW()),
('10000000-0000-0000-0000-000000000014', 'Michelle', 'Moore', '1977-05-26T00:00:00+00:00', 'Female', '555-0120', 'michelle.moore@email.com', '1400 Fourteenth St, Cleveland, OH 44101', NOW(), NOW()),
('10000000-0000-0000-0000-000000000015', 'Andrew', 'Martin', '1984-09-11T00:00:00+00:00', 'Male', '555-0121', 'andrew.martin@email.com', '1500 Fifteenth Ave, New Orleans, LA 70112', NOW(), NOW()),
('10000000-0000-0000-0000-000000000016', 'Stephanie', 'Jackson', '1961-12-30T00:00:00+00:00', 'Female', '555-0122', 'stephanie.jackson@email.com', '1600 Sixteenth St, Kansas City, MO 64108', NOW(), NOW()),
('10000000-0000-0000-0000-000000000017', 'Kenneth', 'Thompson', '1989-03-07T00:00:00+00:00', 'Male', '555-0123', 'kenneth.thompson@email.com', '1700 Seventeenth Ave, Mesa, AZ 85201', NOW(), NOW()),
('10000000-0000-0000-0000-000000000018', 'Nicole', 'White', '1996-07-14T00:00:00+00:00', 'Female', '555-0124', 'nicole.white@email.com', '1800 Eighteenth St, Virginia Beach, VA 23451', NOW(), NOW()),
('10000000-0000-0000-0000-000000000019', 'Ryan', 'Harris', '1972-11-01T00:00:00+00:00', 'Male', '555-0125', 'ryan.harris@email.com', '1900 Nineteenth Ave, Omaha, NE 68102', NOW(), NOW()),
('10000000-0000-0000-0000-000000000020', 'Rachel', 'Clark', '1983-02-18T00:00:00+00:00', 'Female', '555-0126', 'rachel.clark@email.com', '2000 Twentieth St, Long Beach, CA 90802', NOW(), NOW()),
('10000000-0000-0000-0000-000000000021', 'Brian', 'Lewis', '1967-06-25T00:00:00+00:00', 'Male', '555-0127', 'brian.lewis@email.com', '2100 Twenty-First Ave, Oakland, CA 94607', NOW(), NOW()),
('10000000-0000-0000-0000-000000000022', 'Laura', 'Robinson', '1993-10-12T00:00:00+00:00', 'Female', '555-0128', 'laura.robinson@email.com', '2200 Twenty-Second St, Albuquerque, NM 87102', NOW(), NOW()),
('10000000-0000-0000-0000-000000000023', 'Jason', 'Walker', '1980-01-29T00:00:00+00:00', 'Male', '555-0129', 'jason.walker@email.com', '2300 Twenty-Third Ave, Tucson, AZ 85701', NOW(), NOW()),
('10000000-0000-0000-0000-000000000024', 'Angela', 'Perez', '1976-05-16T00:00:00+00:00', 'Female', '555-0130', 'angela.perez@email.com', '2400 Twenty-Fourth St, Fresno, CA 93721', NOW(), NOW()),
('10000000-0000-0000-0000-000000000025', 'Kevin', 'Hall', '1988-09-03T00:00:00+00:00', 'Male', '555-0131', 'kevin.hall@email.com', '2500 Twenty-Fifth Ave, Sacramento, CA 95814', NOW(), NOW()),
('10000000-0000-0000-0000-000000000026', 'Kimberly', 'Young', '1964-12-20T00:00:00+00:00', 'Female', '555-0132', 'kimberly.young@email.com', '2600 Twenty-Sixth St, Kansas City, KS 66101', NOW(), NOW()),
('10000000-0000-0000-0000-000000000027', 'Steven', 'Allen', '1991-04-07T00:00:00+00:00', 'Male', '555-0133', 'steven.allen@email.com', '2700 Twenty-Seventh Ave, Mesa, AZ 85201', NOW(), NOW()),
('10000000-0000-0000-0000-000000000028', 'Donna', 'King', '1979-08-24T00:00:00+00:00', 'Female', '555-0134', 'donna.king@email.com', '2800 Twenty-Eighth St, Atlanta, GA 30309', NOW(), NOW()),
('10000000-0000-0000-0000-000000000029', 'Edward', 'Wright', '1974-01-11T00:00:00+00:00', 'Male', '555-0135', 'edward.wright@email.com', '2900 Twenty-Ninth Ave, Colorado Springs, CO 80903', NOW(), NOW()),
('10000000-0000-0000-0000-000000000030', 'Carol', 'Lopez', '1997-05-28T00:00:00+00:00', 'Female', '555-0136', 'carol.lopez@email.com', '3000 Thirtieth St, Raleigh, NC 27601', NOW(), NOW()),
('10000000-0000-0000-0000-000000000031', 'Timothy', 'Hill', '1966-09-15T00:00:00+00:00', 'Male', '555-0137', 'timothy.hill@email.com', '3100 Thirty-First Ave, Miami, FL 33131', NOW(), NOW()),
('10000000-0000-0000-0000-000000000032', 'Lisa', 'Scott', '1985-02-02T00:00:00+00:00', 'Female', '555-0138', 'lisa.scott@email.com', '3200 Thirty-Second St, Virginia Beach, VA 23451', NOW(), NOW()),
('10000000-0000-0000-0000-000000000033', 'Frank', 'Green', '1971-06-19T00:00:00+00:00', 'Male', '555-0139', 'frank.green@email.com', '3300 Thirty-Third Ave, Newark, NJ 07102', NOW(), NOW()),
('10000000-0000-0000-0000-000000000034', 'Helen', 'Adams', '1992-10-06T00:00:00+00:00', 'Female', '555-0140', 'helen.adams@email.com', '3400 Thirty-Fourth St, Buffalo, NY 14202', NOW(), NOW()),
('10000000-0000-0000-0000-000000000035', 'Gregory', 'Baker', '1958-03-23T00:00:00+00:00', 'Male', '555-0141', 'gregory.baker@email.com', '3500 Thirty-Fifth Ave, Toledo, OH 43604', NOW(), NOW()),
('10000000-0000-0000-0000-000000000036', 'Deborah', 'Gonzalez', '1987-07-10T00:00:00+00:00', 'Female', '555-0142', 'deborah.gonzalez@email.com', '3600 Thirty-Sixth St, Riverside, CA 92501', NOW(), NOW()),
('10000000-0000-0000-0000-000000000037', 'Raymond', 'Nelson', '1975-11-27T00:00:00+00:00', 'Male', '555-0143', 'raymond.nelson@email.com', '3700 Thirty-Seventh Ave, Lexington, KY 40507', NOW(), NOW()),
('10000000-0000-0000-0000-000000000038', 'Sharon', 'Carter', '1984-04-14T00:00:00+00:00', 'Female', '555-0144', 'sharon.carter@email.com', '3800 Thirty-Eighth St, Corpus Christi, TX 78401', NOW(), NOW()),
('10000000-0000-0000-0000-000000000039', 'Jerry', 'Mitchell', '1969-08-01T00:00:00+00:00', 'Male', '555-0145', 'jerry.mitchell@email.com', '3900 Thirty-Ninth Ave, Pittsburgh, PA 15219', NOW(), NOW()),
('10000000-0000-0000-0000-000000000040', 'Cynthia', 'Perez', '1994-12-18T00:00:00+00:00', 'Female', '555-0146', 'cynthia.perez@email.com', '4000 Fortieth St, Aurora, CO 80012', NOW(), NOW()),
('10000000-0000-0000-0000-000000000041', 'Dennis', 'Roberts', '1962-05-05T00:00:00+00:00', 'Male', '555-0147', 'dennis.roberts@email.com', '4100 Forty-First Ave, Stockton, CA 95202', NOW(), NOW()),
('10000000-0000-0000-0000-000000000042', 'Amy', 'Turner', '1989-09-22T00:00:00+00:00', 'Female', '555-0148', 'amy.turner@email.com', '4200 Forty-Second St, Birmingham, AL 35203', NOW(), NOW()),
('10000000-0000-0000-0000-000000000043', 'Walter', 'Phillips', '1976-02-09T00:00:00+00:00', 'Male', '555-0149', 'walter.phillips@email.com', '4300 Forty-Third Ave, Rochester, NY 14604', NOW(), NOW()),
('10000000-0000-0000-0000-000000000044', 'Kathleen', 'Campbell', '1981-06-26T00:00:00+00:00', 'Female', '555-0150', 'kathleen.campbell@email.com', '4400 Forty-Fourth St, Jersey City, NJ 07302', NOW(), NOW()),
('10000000-0000-0000-0000-000000000045', 'Patrick', 'Parker', '1968-10-13T00:00:00+00:00', 'Male', '555-0151', 'patrick.parker@email.com', '4500 Forty-Fifth Ave, Norfolk, VA 23510', NOW(), NOW()),
('10000000-0000-0000-0000-000000000046', 'Brenda', 'Evans', '1995-03-30T00:00:00+00:00', 'Female', '555-0152', 'brenda.evans@email.com', '4600 Forty-Sixth St, Chandler, AZ 85225', NOW(), NOW()),
('10000000-0000-0000-0000-000000000047', 'Harold', 'Edwards', '1973-07-17T00:00:00+00:00', 'Male', '555-0153', 'harold.edwards@email.com', '4700 Forty-Seventh Ave, Laredo, TX 78040', NOW(), NOW()),
('10000000-0000-0000-0000-000000000048', 'Emma', 'Collins', '1990-11-04T00:00:00+00:00', 'Female', '555-0154', 'emma.collins@email.com', '4800 Forty-Eighth St, Madison, WI 53703', NOW(), NOW()),
('10000000-0000-0000-0000-000000000049', 'Arthur', 'Stewart', '1965-04-21T00:00:00+00:00', 'Male', '555-0155', 'arthur.stewart@email.com', '4900 Forty-Ninth Ave, Lubbock, TX 79401', NOW(), NOW()),
('10000000-0000-0000-0000-000000000050', 'Olivia', 'Sanchez', '1986-08-08T00:00:00+00:00', 'Female', '555-0156', 'olivia.sanchez@email.com', '5000 Fiftieth St, Baton Rouge, LA 70802', NOW(), NOW()),
('10000000-0000-0000-0000-000000000051', 'Eugene', 'Morris', '1977-12-25T00:00:00+00:00', 'Male', '555-0157', 'eugene.morris@email.com', '5100 Fifty-First Ave, Akron, OH 44308', NOW(), NOW()),
('10000000-0000-0000-0000-000000000052', 'Frances', 'Reed', '1993-05-12T00:00:00+00:00', 'Female', '555-0158', 'frances.reed@email.com', '5200 Fifty-Second St, Richmond, VA 23220', NOW(), NOW()),
('10000000-0000-0000-0000-000000000053', 'Wayne', 'Cook', '1960-09-29T00:00:00+00:00', 'Male', '555-0159', 'wayne.cook@email.com', '5300 Fifty-Third Ave, Des Moines, IA 50309', NOW(), NOW()),
('10000000-0000-0000-0000-000000000054', 'Evelyn', 'Morgan', '1988-02-16T00:00:00+00:00', 'Female', '555-0160', 'evelyn.morgan@email.com', '5400 Fifty-Fourth St, Tacoma, WA 98402', NOW(), NOW()),
('10000000-0000-0000-0000-000000000055', 'Ralph', 'Bell', '1974-06-03T00:00:00+00:00', 'Male', '555-0161', 'ralph.bell@email.com', '5500 Fifty-Fifth Ave, San Bernardino, CA 92410', NOW(), NOW()),
('10000000-0000-0000-0000-000000000056', 'Gloria', 'Murphy', '1982-10-20T00:00:00+00:00', 'Female', '555-0162', 'gloria.murphy@email.com', '5600 Fifty-Sixth St, Spokane, WA 99201', NOW(), NOW()),
('10000000-0000-0000-0000-000000000057', 'Roy', 'Bailey', '1971-03-07T00:00:00+00:00', 'Male', '555-0163', 'roy.bailey@email.com', '5700 Fifty-Seventh Ave, Fontana, CA 92335', NOW(), NOW()),
('10000000-0000-0000-0000-000000000058', 'Theresa', 'Rivera', '1996-07-24T00:00:00+00:00', 'Female', '555-0164', 'theresa.rivera@email.com', '5800 Fifty-Eighth St, Santa Clarita, CA 91321', NOW(), NOW()),
('10000000-0000-0000-0000-000000000059', 'Louis', 'Cooper', '1967-11-11T00:00:00+00:00', 'Male', '555-0165', 'louis.cooper@email.com', '5900 Fifty-Ninth Ave, Knoxville, TN 37902', NOW(), NOW()),
('10000000-0000-0000-0000-000000000060', 'Marie', 'Richardson', '1985-04-28T00:00:00+00:00', 'Female', '555-0166', 'marie.richardson@email.com', '6000 Sixtieth St, Worcester, MA 01608', NOW(), NOW()),
('10000000-0000-0000-0000-000000000061', 'Philip', 'Cox', '1978-08-15T00:00:00+00:00', 'Male', '555-0167', 'philip.cox@email.com', '6100 Sixty-First Ave, Fort Wayne, IN 46802', NOW(), NOW()),
('10000000-0000-0000-0000-000000000062', 'Janet', 'Howard', '1991-01-02T00:00:00+00:00', 'Female', '555-0168', 'janet.howard@email.com', '6200 Sixty-Second St, Mobile, AL 36602', NOW(), NOW()),
('10000000-0000-0000-0000-000000000063', 'Johnny', 'Ward', '1964-05-19T00:00:00+00:00', 'Male', '555-0169', 'johnny.ward@email.com', '6300 Sixty-Third Ave, Shreveport, LA 71101', NOW(), NOW()),
('10000000-0000-0000-0000-000000000064', 'Catherine', 'Torres', '1987-09-06T00:00:00+00:00', 'Female', '555-0170', 'catherine.torres@email.com', '6400 Sixty-Fourth St, Honolulu, HI 96813', NOW(), NOW()),
('10000000-0000-0000-0000-000000000065', 'Bobby', 'Peterson', '1975-12-23T00:00:00+00:00', 'Male', '555-0171', 'bobby.peterson@email.com', '6500 Sixty-Fifth Ave, Aurora, IL 60505', NOW(), NOW()),
('10000000-0000-0000-0000-000000000066', 'Virginia', 'Gray', '1983-04-10T00:00:00+00:00', 'Female', '555-0172', 'virginia.gray@email.com', '6600 Sixty-Sixth St, Rockford, IL 61104', NOW(), NOW()),
('10000000-0000-0000-0000-000000000067', 'Douglas', 'Ramirez', '1970-08-27T00:00:00+00:00', 'Male', '555-0173', 'douglas.ramirez@email.com', '6700 Sixty-Seventh Ave, Newport News, VA 23601', NOW(), NOW()),
('10000000-0000-0000-0000-000000000068', 'Jacqueline', 'James', '1994-01-14T00:00:00+00:00', 'Female', '555-0174', 'jacqueline.james@email.com', '6800 Sixty-Eighth St, Bridgeport, CT 06604', NOW(), NOW()),
('10000000-0000-0000-0000-000000000069', 'Henry', 'Watson', '1962-06-01T00:00:00+00:00', 'Male', '555-0175', 'henry.watson@email.com', '6900 Sixty-Ninth Ave, Salt Lake City, UT 84111', NOW(), NOW()),
('10000000-0000-0000-0000-000000000070', 'Pamela', 'Brooks', '1989-10-18T00:00:00+00:00', 'Female', '555-0176', 'pamela.brooks@email.com', '7000 Seventieth St, Little Rock, AR 72201', NOW(), NOW()),
('10000000-0000-0000-0000-000000000071', 'Carl', 'Kelly', '1976-03-05T00:00:00+00:00', 'Male', '555-0177', 'carl.kelly@email.com', '7100 Seventy-First Ave, Huntington, WV 25701', NOW(), NOW()),
('10000000-0000-0000-0000-000000000072', 'Carolyn', 'Sanders', '1984-07-22T00:00:00+00:00', 'Female', '555-0178', 'carolyn.sanders@email.com', '7200 Seventy-Second St, Columbus, GA 31901', NOW(), NOW()),
('10000000-0000-0000-0000-000000000073', 'Peter', 'Price', '1968-11-09T00:00:00+00:00', 'Male', '555-0179', 'peter.price@email.com', '7300 Seventy-Third Ave, Grand Rapids, MI 49503', NOW(), NOW()),
('10000000-0000-0000-0000-000000000074', 'Ruth', 'Bennett', '1995-02-26T00:00:00+00:00', 'Female', '555-0180', 'ruth.bennett@email.com', '7400 Seventy-Fourth St, Tallahassee, FL 32301', NOW(), NOW()),
('10000000-0000-0000-0000-000000000075', 'George', 'Wood', '1973-06-13T00:00:00+00:00', 'Male', '555-0181', 'george.wood@email.com', '7500 Seventy-Fifth Ave, Montgomery, AL 36104', NOW(), NOW()),
('10000000-0000-0000-0000-000000000076', 'Maria', 'Barnes', '1990-10-30T00:00:00+00:00', 'Female', '555-0182', 'maria.barnes@email.com', '7600 Seventy-Sixth St, Amarillo, TX 79101', NOW(), NOW()),
('10000000-0000-0000-0000-000000000077', 'Jack', 'Ross', '1966-03-17T00:00:00+00:00', 'Male', '555-0183', 'jack.ross@email.com', '7700 Seventy-Seventh Ave, Providence, RI 02903', NOW(), NOW()),
('10000000-0000-0000-0000-000000000078', 'Joan', 'Henderson', '1988-07-04T00:00:00+00:00', 'Female', '555-0184', 'joan.henderson@email.com', '7800 Seventy-Eighth St, Overland Park, KS 66204', NOW(), NOW()),
('10000000-0000-0000-0000-000000000079', 'Albert', 'Coleman', '1977-11-21T00:00:00+00:00', 'Male', '555-0185', 'albert.coleman@email.com', '7900 Seventy-Ninth Ave, Garden Grove, CA 92840', NOW(), NOW()),
('10000000-0000-0000-0000-000000000080', 'Doris', 'Jenkins', '1985-04-08T00:00:00+00:00', 'Female', '555-0186', 'doris.jenkins@email.com', '8000 Eightieth St, Santa Clarita, CA 91321', NOW(), NOW()),
('10000000-0000-0000-0000-000000000081', 'Willie', 'Perry', '1972-08-25T00:00:00+00:00', 'Male', '555-0187', 'willie.perry@email.com', '8100 Eighty-First Ave, Chattanooga, TN 37402', NOW(), NOW()),
('10000000-0000-0000-0000-000000000082', 'Sandra', 'Powell', '1993-01-12T00:00:00+00:00', 'Female', '555-0188', 'sandra.powell@email.com', '8200 Eighty-Second St, Oceanside, CA 92054', NOW(), NOW()),
('10000000-0000-0000-0000-000000000083', 'Lawrence', 'Long', '1961-05-29T00:00:00+00:00', 'Male', '555-0189', 'lawrence.long@email.com', '8300 Eighty-Third Ave, Santa Rosa, CA 95404', NOW(), NOW()),
('10000000-0000-0000-0000-000000000084', 'Betty', 'Patterson', '1987-09-16T00:00:00+00:00', 'Female', '555-0190', 'betty.patterson@email.com', '8400 Eighty-Fourth St, Salinas, CA 93901', NOW(), NOW()),
('10000000-0000-0000-0000-000000000085', 'Joe', 'Hughes', '1974-02-03T00:00:00+00:00', 'Male', '555-0191', 'joe.hughes@email.com', '8500 Eighty-Fifth Ave, Grand Prairie, TX 75050', NOW(), NOW()),
('10000000-0000-0000-0000-000000000086', 'Helen', 'Flores', '1992-06-20T00:00:00+00:00', 'Female', '555-0192', 'helen.flores@email.com', '8600 Eighty-Sixth St, McKinney, TX 75069', NOW(), NOW()),
('10000000-0000-0000-0000-000000000087', 'Alan', 'Washington', '1969-10-07T00:00:00+00:00', 'Male', '555-0193', 'alan.washington@email.com', '8700 Eighty-Seventh Ave, Sioux Falls, SD 57104', NOW(), NOW()),
('10000000-0000-0000-0000-000000000088', 'Diane', 'Butler', '1986-02-24T00:00:00+00:00', 'Female', '555-0194', 'diane.butler@email.com', '8800 Eighty-Eighth St, Peoria, IL 61602', NOW(), NOW()),
('10000000-0000-0000-0000-000000000089', 'Roger', 'Simmons', '1978-07-11T00:00:00+00:00', 'Male', '555-0195', 'roger.simmons@email.com', '8900 Eighty-Ninth Ave, Evansville, IN 47708', NOW(), NOW()),
('10000000-0000-0000-0000-000000000090', 'Julie', 'Foster', '1991-11-28T00:00:00+00:00', 'Female', '555-0196', 'julie.foster@email.com', '9000 Ninetieth St, Springfield, MO 65806', NOW(), NOW()),
('10000000-0000-0000-0000-000000000091', 'Terry', 'Gonzales', '1965-04-15T00:00:00+00:00', 'Male', '555-0197', 'terry.gonzales@email.com', '9100 Ninety-First Ave, Carrollton, TX 75006', NOW(), NOW()),
('10000000-0000-0000-0000-000000000092', 'Joyce', 'Bryant', '1989-08-02T00:00:00+00:00', 'Female', '555-0198', 'joyce.bryant@email.com', '9200 Ninety-Second St, Coral Springs, FL 33065', NOW(), NOW()),
('10000000-0000-0000-0000-000000000093', 'Sean', 'Alexander', '1975-12-19T00:00:00+00:00', 'Male', '555-0199', 'sean.alexander@email.com', '9300 Ninety-Third Ave, Stamford, CT 06901', NOW(), NOW()),
('10000000-0000-0000-0000-000000000094', 'Jane', 'Russell', '1983-05-06T00:00:00+00:00', 'Female', '555-0200', 'jane.russell@email.com', '9400 Ninety-Fourth St, Simi Valley, CA 93065', NOW(), NOW()),
('10000000-0000-0000-0000-000000000095', 'Scott', 'Griffin', '1970-09-23T00:00:00+00:00', 'Male', '555-0201', 'scott.griffin@email.com', '9500 Ninety-Fifth Ave, Concord, CA 94520', NOW(), NOW()),
('10000000-0000-0000-0000-000000000096', 'Cheryl', 'Diaz', '1996-02-10T00:00:00+00:00', 'Female', '555-0202', 'cheryl.diaz@email.com', '9600 Ninety-Sixth St, Hartford, CT 06103', NOW(), NOW()),
('10000000-0000-0000-0000-000000000097', 'Howard', 'Hayes', '1964-06-27T00:00:00+00:00', 'Male', '555-0203', 'howard.hayes@email.com', '9700 Ninety-Seventh Ave, Roseville, CA 95678', NOW(), NOW()),
('10000000-0000-0000-0000-000000000098', 'Katherine', 'Myers', '1988-10-14T00:00:00+00:00', 'Female', '555-0204', 'katherine.myers@email.com', '9800 Ninety-Eighth St, Sterling Heights, MI 48310', NOW(), NOW()),
('10000000-0000-0000-0000-000000000099', 'Samuel', 'Ford', '1979-03-01T00:00:00+00:00', 'Male', '555-0205', 'samuel.ford@email.com', '9900 Ninety-Ninth Ave, Cedar Rapids, IA 52402', NOW(), NOW()),
('10000000-0000-0000-0000-000000000100', 'Beverly', 'Harvey', '1984-07-18T00:00:00+00:00', 'Female', '555-0206', 'beverly.harvey@email.com', '10000 One Hundredth St, Round Rock, TX 78664', NOW(), NOW());

-- Insert Medical Conditions (diverse range of conditions across patient population)
INSERT INTO "MedicalConditions" ("Id", "PatientId", "Name", "Description", "Severity", "Symptoms", "Causes", "Treatments") VALUES
-- Original 6 patients conditions
('11111111-aaaa-aaaa-aaaa-111111111111', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'Type 2 Diabetes Mellitus', 'Chronic metabolic disorder characterized by high blood sugar levels due to insulin resistance', 'Moderate', 'Increased thirst, frequent urination, fatigue, blurred vision, slow healing wounds', 'Insulin resistance, obesity, sedentary lifestyle, genetic factors', 'Metformin, lifestyle modifications, blood glucose monitoring, dietary counseling'),
('22222222-bbbb-bbbb-bbbb-222222222222', 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'Essential Hypertension', 'Persistent elevation of systemic arterial blood pressure', 'Mild', 'Often asymptomatic, occasional headaches, dizziness', 'Genetic predisposition, dietary factors, stress, age', 'ACE inhibitors, lifestyle modifications, sodium restriction, regular exercise'),
('33333333-cccc-cccc-cccc-333333333333', 'cccccccc-cccc-cccc-cccc-cccccccccccc', 'Osteoarthritis of Knees', 'Degenerative joint disease affecting knee cartilage', 'Moderate', 'Joint pain, stiffness, reduced range of motion, swelling', 'Age-related wear and tear, previous injury, obesity', 'NSAIDs, physical therapy, weight management, joint injections'),
('44444444-dddd-dddd-dddd-444444444444', 'dddddddd-dddd-dddd-dddd-dddddddddddd', 'Bronchial Asthma', 'Chronic inflammatory airway disease causing reversible airflow obstruction', 'Mild', 'Wheezing, shortness of breath, chest tightness, cough', 'Environmental allergens, family history, air pollution', 'Inhaled corticosteroids, bronchodilators, allergen avoidance'),
('55555555-eeee-eeee-eeee-555555555555', 'eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', 'Chronic Kidney Disease Stage 3', 'Progressive loss of kidney function over time', 'Moderate', 'Fatigue, swelling in legs, decreased urine output, high blood pressure', 'Diabetes, hypertension, age-related decline', 'ACE inhibitors, phosphate binders, dietary restrictions, regular monitoring'),
('66666666-ffff-ffff-ffff-666666666666', 'ffffffff-ffff-ffff-ffff-ffffffffffff', 'Generalized Anxiety Disorder', 'Chronic condition characterized by excessive worry and anxiety', 'Moderate', 'Persistent worry, restlessness, fatigue, difficulty concentrating, sleep disturbances', 'Genetic factors, stress, traumatic events, brain chemistry imbalance', 'Cognitive behavioral therapy, SSRIs, stress management techniques'),

-- Additional conditions for expanded patient population
('10000001-0001-0001-0001-000000000001', '10000000-0000-0000-0000-000000000001', 'Coronary Artery Disease', 'Narrowing of coronary arteries due to atherosclerotic plaque buildup', 'Severe', 'Chest pain, shortness of breath, fatigue, heart palpitations', 'High cholesterol, smoking, diabetes, family history', 'Statins, beta-blockers, antiplatelet therapy, cardiac catheterization'),
('10000001-0001-0001-0001-000000000002', '10000000-0000-0000-0000-000000000002', 'Fibromyalgia', 'Chronic widespread musculoskeletal pain disorder', 'Moderate', 'Widespread pain, fatigue, sleep problems, cognitive difficulties', 'Unknown etiology, possibly genetic and environmental factors', 'Pain management, exercise therapy, stress reduction, sleep hygiene'),
('10000001-0001-0001-0001-000000000003', '10000000-0000-0000-0000-000000000003', 'Gastroesophageal Reflux Disease', 'Chronic condition where stomach acid flows back into esophagus', 'Mild', 'Heartburn, regurgitation, chest pain, difficulty swallowing', 'Hiatal hernia, obesity, certain foods, smoking', 'Proton pump inhibitors, dietary modifications, weight loss'),
('10000001-0001-0001-0001-000000000004', '10000000-0000-0000-0000-000000000004', 'Rheumatoid Arthritis', 'Autoimmune inflammatory disorder affecting joints', 'Moderate', 'Joint pain, swelling, stiffness, fatigue, fever', 'Autoimmune response, genetic predisposition', 'DMARDs, biologics, corticosteroids, physical therapy'),
('10000001-0001-0001-0001-000000000005', '10000000-0000-0000-0000-000000000005', 'Chronic Obstructive Pulmonary Disease', 'Progressive lung disease causing airflow limitation', 'Moderate', 'Chronic cough, shortness of breath, wheezing, excess mucus', 'Smoking, air pollution, occupational exposure', 'Bronchodilators, inhaled corticosteroids, oxygen therapy, pulmonary rehabilitation'),
('10000001-0001-0001-0001-000000000006', '10000000-0000-0000-0000-000000000006', 'Major Depressive Disorder', 'Persistent mood disorder characterized by depressed mood', 'Moderate', 'Persistent sadness, loss of interest, fatigue, sleep changes', 'Brain chemistry imbalance, genetics, life events', 'Antidepressants, psychotherapy, lifestyle changes'),
('10000001-0001-0001-0001-000000000007', '10000000-0000-0000-0000-000000000007', 'Atrial Fibrillation', 'Irregular and often rapid heart rhythm disorder', 'Moderate', 'Heart palpitations, fatigue, dizziness, chest pain', 'Age, heart disease, high blood pressure, thyroid disorders', 'Anticoagulants, rate control medications, rhythm control'),
('10000001-0001-0001-0001-000000000008', '10000000-0000-0000-0000-000000000008', 'Hypothyroidism', 'Underactive thyroid gland producing insufficient hormones', 'Mild', 'Fatigue, weight gain, cold intolerance, dry skin', 'Autoimmune disease, radiation therapy, medications', 'Thyroid hormone replacement therapy'),
('10000001-0001-0001-0001-000000000009', '10000000-0000-0000-0000-000000000009', 'Migraine Headaches', 'Recurring moderate to severe headaches', 'Moderate', 'Severe headache, nausea, light sensitivity, visual disturbances', 'Genetic factors, hormonal changes, stress, certain foods', 'Triptans, preventive medications, lifestyle modifications'),
('10000001-0001-0001-0001-000000000010', '10000000-0000-0000-0000-000000000010', 'Sleep Apnea', 'Sleep disorder characterized by repeated breathing interruptions', 'Moderate', 'Loud snoring, gasping during sleep, daytime sleepiness', 'Obesity, enlarged tonsils, smoking, alcohol use', 'CPAP therapy, weight loss, positional therapy'),
('10000001-0001-0001-0001-000000000011', '10000000-0000-0000-0000-000000000011', 'Osteoporosis', 'Bone disease characterized by decreased bone density', 'Moderate', 'Bone fractures, loss of height, back pain', 'Age, hormonal changes, inadequate calcium, sedentary lifestyle', 'Bisphosphonates, calcium supplements, vitamin D, weight-bearing exercise'),
('10000001-0001-0001-0001-000000000012', '10000000-0000-0000-0000-000000000012', 'Irritable Bowel Syndrome', 'Functional gastrointestinal disorder', 'Mild', 'Abdominal pain, bloating, diarrhea, constipation', 'Unknown, possibly stress, diet, gut bacteria imbalance', 'Dietary modifications, probiotics, antispasmodics, stress management'),
('10000001-0001-0001-0001-000000000013', '10000000-0000-0000-0000-000000000013', 'Bipolar Disorder', 'Mental health condition causing extreme mood swings', 'Moderate', 'Mood swings, manic episodes, depressive episodes', 'Genetic factors, brain structure, environmental triggers', 'Mood stabilizers, antipsychotics, psychotherapy'),
('10000001-0001-0001-0001-000000000014', '10000000-0000-0000-0000-000000000014', 'Peripheral Neuropathy', 'Damage to peripheral nerves causing weakness and pain', 'Moderate', 'Numbness, tingling, burning pain in hands and feet', 'Diabetes, autoimmune diseases, infections, medications', 'Pain management, physical therapy, treatment of underlying cause'),
('10000001-0001-0001-0001-000000000015', '10000000-0000-0000-0000-000000000015', 'Psoriasis', 'Autoimmune skin condition causing rapid skin cell growth', 'Mild', 'Red, scaly patches on skin, itching, burning', 'Autoimmune response, genetic predisposition, stress', 'Topical treatments, phototherapy, systemic medications'),
('10000001-0001-0001-0001-000000000016', '10000000-0000-0000-0000-000000000016', 'Glaucoma', 'Group of eye conditions damaging the optic nerve', 'Mild', 'Gradual vision loss, eye pain, halos around lights', 'Increased intraocular pressure, age, family history', 'Eye drops, laser treatment, surgery'),
('10000001-0001-0001-0001-000000000017', '10000000-0000-0000-0000-000000000017', 'Chronic Fatigue Syndrome', 'Complex disorder characterized by extreme fatigue', 'Moderate', 'Severe fatigue, muscle pain, cognitive problems, sleep issues', 'Unknown, possibly viral infections, immune dysfunction', 'Symptomatic treatment, graded exercise, cognitive behavioral therapy'),
('10000001-0001-0001-0001-000000000018', '10000000-0000-0000-0000-000000000018', 'Lupus', 'Autoimmune disease affecting multiple organ systems', 'Moderate', 'Joint pain, skin rash, fatigue, fever', 'Autoimmune response, genetic and environmental factors', 'Immunosuppressants, corticosteroids, antimalarials'),
('10000001-0001-0001-0001-000000000019', '10000000-0000-0000-0000-000000000019', 'Epilepsy', 'Neurological disorder causing recurrent seizures', 'Moderate', 'Seizures, temporary confusion, staring spells', 'Brain injury, genetics, infections, developmental disorders', 'Antiepileptic drugs, surgery, vagus nerve stimulation'),
('10000001-0001-0001-0001-000000000020', '10000000-0000-0000-0000-000000000020', 'Cataracts', 'Clouding of the natural lens of the eye', 'Mild', 'Blurry vision, light sensitivity, difficulty with night vision', 'Age, diabetes, smoking, prolonged UV exposure', 'Cataract surgery, stronger eyeglasses temporarily'),
('10000001-0001-0001-0001-000000000021', '10000000-0000-0000-0000-000000000021', 'Benign Prostatic Hyperplasia', 'Non-cancerous enlargement of the prostate gland', 'Mild', 'Frequent urination, weak urine stream, incomplete bladder emptying', 'Age, hormonal changes, family history', 'Alpha-blockers, 5-alpha reductase inhibitors, surgery'),
('10000001-0001-0001-0001-000000000022', '10000000-0000-0000-0000-000000000022', 'Endometriosis', 'Condition where uterine tissue grows outside the uterus', 'Moderate', 'Pelvic pain, heavy menstrual bleeding, infertility', 'Unknown, possibly retrograde menstruation, genetics', 'Hormonal therapy, pain medication, surgery'),
('10000001-0001-0001-0001-000000000023', '10000000-0000-0000-0000-000000000023', 'Celiac Disease', 'Autoimmune disorder triggered by gluten consumption', 'Moderate', 'Diarrhea, abdominal pain, bloating, weight loss', 'Genetic predisposition, gluten consumption', 'Strict gluten-free diet, nutritional supplements'),
('10000001-0001-0001-0001-000000000024', '10000000-0000-0000-0000-000000000024', 'Macular Degeneration', 'Eye disease causing central vision loss', 'Moderate', 'Blurred central vision, difficulty reading, dark spots', 'Age, genetics, smoking, high blood pressure', 'Anti-VEGF injections, vitamins, laser therapy'),
('10000001-0001-0001-0001-000000000025', '10000000-0000-0000-0000-000000000025', 'Chronic Sinusitis', 'Long-term inflammation of the sinuses', 'Mild', 'Nasal congestion, facial pain, thick nasal discharge', 'Allergies, nasal polyps, deviated septum, infections', 'Nasal corticosteroids, saline irrigation, antibiotics'),
('10000001-0001-0001-0001-000000000026', '10000000-0000-0000-0000-000000000026', 'Gout', 'Form of arthritis caused by uric acid crystal deposits', 'Moderate', 'Sudden severe joint pain, swelling, redness', 'High uric acid levels, diet, genetics, medications', 'Colchicine, NSAIDs, uric acid-lowering medications'),
('10000001-0001-0001-0001-000000000027', '10000000-0000-0000-0000-000000000027', 'Restless Leg Syndrome', 'Neurological disorder causing leg discomfort', 'Mild', 'Uncomfortable leg sensations, urge to move legs', 'Unknown, possibly genetic, iron deficiency', 'Dopamine agonists, iron supplements, lifestyle changes'),
('10000001-0001-0001-0001-000000000028', '10000000-0000-0000-0000-000000000028', 'Polycystic Ovary Syndrome', 'Hormonal disorder affecting reproductive-aged women', 'Moderate', 'Irregular periods, excess hair growth, weight gain', 'Insulin resistance, genetics, inflammation', 'Hormonal birth control, metformin, lifestyle modifications'),
('10000001-0001-0001-0001-000000000029', '10000000-0000-0000-0000-000000000029', 'Diverticulitis', 'Inflammation of small pouches in the colon wall', 'Moderate', 'Abdominal pain, fever, nausea, changes in bowel habits', 'Low-fiber diet, aging, genetics, lifestyle factors', 'Antibiotics, dietary modifications, surgery if severe'),
('10000001-0001-0001-0001-000000000030', '10000000-0000-0000-0000-000000000030', 'Eczema', 'Chronic skin condition causing inflammation and itching', 'Mild', 'Itchy, red, dry skin patches', 'Genetics, environmental triggers, immune system dysfunction', 'Moisturizers, topical corticosteroids, antihistamines');

-- Insert 50+ Different Types of Allergies across patient population
INSERT INTO "Allergies" ("Id", "PatientId", "Name", "Type", "Severity", "Symptoms", "CommonTriggers", "RecordedDate") VALUES
-- Original patient allergies
('11111111-1111-aaaa-aaaa-111111111111', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'Penicillin Allergy', 'Drug', 'Severe', 'Hives, swelling, difficulty breathing', 'Penicillin, Amoxicillin, Ampicillin', '2020-01-15T10:30:00+00:00'),
('11111111-1111-aaaa-aaaa-111111111112', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'Shellfish Allergy', 'Food', 'Moderate', 'Nausea, vomiting, skin rash', 'Shrimp, Lobster, Crab, Oysters', '2019-05-20T14:15:00+00:00'),
('22222222-2222-bbbb-bbbb-222222222222', 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'Pollen Allergy', 'Environmental', 'Mild', 'Sneezing, runny nose, itchy eyes', 'Tree pollen, Grass pollen, Ragweed', '2021-03-10T09:00:00+00:00'),
('33333333-3333-cccc-cccc-333333333333', 'cccccccc-cccc-cccc-cccc-cccccccccccc', 'Latex Allergy', 'Contact', 'Moderate', 'Skin irritation, redness, swelling', 'Latex gloves, Medical devices, Balloons', '2018-11-25T16:45:00+00:00'),
('44444444-4444-dddd-dddd-444444444444', 'dddddddd-dddd-dddd-dddd-dddddddddddd', 'Dust Mite Allergy', 'Environmental', 'Moderate', 'Congestion, cough, asthma symptoms', 'House dust mites, Bedding, Carpets', '2022-02-14T11:20:00+00:00'),
('44444444-4444-dddd-dddd-444444444445', 'dddddddd-dddd-dddd-dddd-dddddddddddd', 'Cat Dander Allergy', 'Environmental', 'Mild', 'Sneezing, watery eyes, mild wheezing', 'Cat hair, Cat saliva, Cat urine', '2022-02-14T11:25:00+00:00'),
('66666666-6666-ffff-ffff-666666666666', 'ffffffff-ffff-ffff-ffff-ffffffffffff', 'Sulfa Drug Allergy', 'Drug', 'Moderate', 'Skin rash, fever, joint pain', 'Sulfamethoxazole, Trimethoprim', '2020-08-12T13:30:00+00:00'),

-- Additional 43+ diverse allergies across expanded patient population
('20000001-0001-0001-0001-000000000001', '10000000-0000-0000-0000-000000000001', 'Peanut Allergy', 'Food', 'Severe', 'Anaphylaxis, hives, vomiting, difficulty breathing', 'Peanuts, Peanut oil, Cross-contamination', '2023-01-10T08:00:00+00:00'),
('20000001-0001-0001-0001-000000000002', '10000000-0000-0000-0000-000000000002', 'Tree Nut Allergy', 'Food', 'Severe', 'Swelling, hives, difficulty swallowing', 'Almonds, Walnuts, Cashews, Pecans', '2023-02-15T10:30:00+00:00'),
('20000001-0001-0001-0001-000000000003', '10000000-0000-0000-0000-000000000003', 'Milk Allergy', 'Food', 'Moderate', 'Digestive issues, skin rash, respiratory problems', 'Cow milk, Dairy products, Casein', '2023-03-20T14:45:00+00:00'),
('20000001-0001-0001-0001-000000000004', '10000000-0000-0000-0000-000000000004', 'Egg Allergy', 'Food', 'Moderate', 'Skin reactions, digestive problems, respiratory symptoms', 'Chicken eggs, Egg proteins in vaccines', '2023-04-25T09:15:00+00:00'),
('20000001-0001-0001-0001-000000000005', '10000000-0000-0000-0000-000000000005', 'Soy Allergy', 'Food', 'Mild', 'Stomach upset, skin rash, nasal congestion', 'Soybeans, Soy sauce, Tofu, Soy milk', '2023-05-30T11:20:00+00:00'),
('20000001-0001-0001-0001-000000000006', '10000000-0000-0000-0000-000000000006', 'Wheat Allergy', 'Food', 'Moderate', 'Digestive issues, skin reactions, respiratory problems', 'Wheat products, Gluten, Flour', '2023-06-10T16:00:00+00:00'),
('20000001-0001-0001-0001-000000000007', '10000000-0000-0000-0000-000000000007', 'Fish Allergy', 'Food', 'Moderate', 'Nausea, vomiting, skin reactions', 'Salmon, Tuna, Cod, Fish sauce', '2023-07-15T13:30:00+00:00'),
('20000001-0001-0001-0001-000000000008', '10000000-0000-0000-0000-000000000008', 'Sesame Allergy', 'Food', 'Moderate', 'Skin rash, digestive problems, respiratory symptoms', 'Sesame seeds, Tahini, Sesame oil', '2023-08-20T10:45:00+00:00'),
('20000001-0001-0001-0001-000000000009', '10000000-0000-0000-0000-000000000009', 'Aspirin Allergy', 'Drug', 'Moderate', 'Asthma symptoms, skin reactions, nasal congestion', 'Aspirin, NSAIDs, Salicylates', '2023-09-25T14:15:00+00:00'),
('20000001-0001-0001-0001-000000000010', '10000000-0000-0000-0000-000000000010', 'Ibuprofen Allergy', 'Drug', 'Mild', 'Skin rash, stomach upset, mild swelling', 'Ibuprofen, Advil, Motrin', '2023-10-30T09:00:00+00:00'),
('20000001-0001-0001-0001-000000000011', '10000000-0000-0000-0000-000000000011', 'Codeine Allergy', 'Drug', 'Moderate', 'Nausea, vomiting, skin rash, drowsiness', 'Codeine, Morphine derivatives', '2023-11-15T15:30:00+00:00'),
('20000001-0001-0001-0001-000000000012', '10000000-0000-0000-0000-000000000012', 'Bee Sting Allergy', 'Insect', 'Severe', 'Anaphylaxis, severe swelling, difficulty breathing', 'Bee stings, Wasp stings, Hornet stings', '2023-12-20T12:00:00+00:00'),
('20000001-0001-0001-0001-000000000013', '10000000-0000-0000-0000-000000000013', 'Dog Dander Allergy', 'Environmental', 'Mild', 'Sneezing, runny nose, itchy eyes', 'Dog hair, Dog saliva, Dog dander', '2024-01-25T08:30:00+00:00'),
('20000001-0001-0001-0001-000000000014', '10000000-0000-0000-0000-000000000014', 'Mold Allergy', 'Environmental', 'Moderate', 'Coughing, wheezing, nasal congestion, eye irritation', 'Indoor mold, Outdoor mold spores', '2024-02-28T11:45:00+00:00'),
('20000001-0001-0001-0001-000000000015', '10000000-0000-0000-0000-000000000015', 'Ragweed Allergy', 'Environmental', 'Moderate', 'Seasonal rhinitis, sneezing, congestion', 'Ragweed pollen, Fall allergens', '2024-03-15T14:00:00+00:00'),
('20000001-0001-0001-0001-000000000016', '10000000-0000-0000-0000-000000000016', 'Nickel Allergy', 'Contact', 'Mild', 'Contact dermatitis, skin rash, itching', 'Jewelry, Belt buckles, Coins', '2024-04-20T16:15:00+00:00'),
('20000001-0001-0001-0001-000000000017', '10000000-0000-0000-0000-000000000017', 'Fragrance Allergy', 'Contact', 'Mild', 'Skin irritation, headaches, respiratory symptoms', 'Perfumes, Scented products, Cosmetics', '2024-05-25T09:30:00+00:00'),
('20000001-0001-0001-0001-000000000018', '10000000-0000-0000-0000-000000000018', 'Formaldehyde Allergy', 'Contact', 'Moderate', 'Skin rash, eye irritation, respiratory problems', 'Building materials, Cosmetics, Fabrics', '2024-06-30T13:45:00+00:00'),
('20000001-0001-0001-0001-000000000019', '10000000-0000-0000-0000-000000000019', 'Chocolate Allergy', 'Food', 'Mild', 'Mild skin rash, stomach upset', 'Chocolate, Cocoa products, Theobromine', '2024-07-15T10:00:00+00:00'),
('20000001-0001-0001-0001-000000000020', '10000000-0000-0000-0000-000000000020', 'Strawberry Allergy', 'Food', 'Mild', 'Oral allergy syndrome, mild skin reactions', 'Fresh strawberries, Strawberry products', '2024-08-20T15:20:00+00:00'),
('20000001-0001-0001-0001-000000000021', '10000000-0000-0000-0000-000000000021', 'Tomato Allergy', 'Food', 'Mild', 'Oral tingling, mild digestive upset', 'Tomatoes, Tomato sauce, Ketchup', '2024-09-25T11:30:00+00:00'),
('20000001-0001-0001-0001-000000000022', '10000000-0000-0000-0000-000000000022', 'Avocado Allergy', 'Food', 'Moderate', 'Oral allergy syndrome, skin reactions', 'Avocados, Guacamole, Cross-reaction with latex', '2024-10-30T14:45:00+00:00'),
('20000001-0001-0001-0001-000000000023', '10000000-0000-0000-0000-000000000023', 'Kiwi Allergy', 'Food', 'Moderate', 'Oral tingling, throat swelling, skin rash', 'Kiwi fruit, Cross-reaction with birch pollen', '2024-11-15T08:15:00+00:00'),
('20000001-0001-0001-0001-000000000024', '10000000-0000-0000-0000-000000000024', 'Banana Allergy', 'Food', 'Mild', 'Oral allergy syndrome, mild digestive issues', 'Bananas, Cross-reaction with latex', '2024-12-20T12:30:00+00:00'),
('20000001-0001-0001-0001-000000000025', '10000000-0000-0000-0000-000000000025', 'Celery Allergy', 'Food', 'Moderate', 'Oral allergy syndrome, systemic reactions', 'Celery, Celeriac, Spices containing celery', '2025-01-25T16:00:00+00:00'),
('20000001-0001-0001-0001-000000000026', '10000000-0000-0000-0000-000000000026', 'Mustard Allergy', 'Food', 'Moderate', 'Skin reactions, respiratory symptoms', 'Mustard seeds, Mustard sauce, Condiments', '2025-02-28T09:45:00+00:00'),
('20000001-0001-0001-0001-000000000027', '10000000-0000-0000-0000-000000000027', 'Sulfite Allergy', 'Food Additive', 'Moderate', 'Asthma symptoms, skin reactions', 'Wine, Dried fruits, Processed foods', '2025-03-15T13:15:00+00:00'),
('20000001-0001-0001-0001-000000000028', '10000000-0000-0000-0000-000000000028', 'MSG Allergy', 'Food Additive', 'Mild', 'Headaches, flushing, sweating', 'Chinese food, Processed foods, Flavor enhancers', '2025-04-20T10:30:00+00:00'),
('20000001-0001-0001-0001-000000000029', '10000000-0000-0000-0000-000000000029', 'Red Dye Allergy', 'Food Additive', 'Mild', 'Hyperactivity, skin rash, digestive upset', 'Red food coloring, Candies, Beverages', '2025-05-25T14:45:00+00:00'),
('20000001-0001-0001-0001-000000000030', '10000000-0000-0000-0000-000000000030', 'Birch Pollen Allergy', 'Environmental', 'Moderate', 'Seasonal rhinitis, eye irritation', 'Birch trees, Spring pollen, Cross-reactive foods', '2025-06-30T11:00:00+00:00'),
('20000001-0001-0001-0001-000000000031', '10000000-0000-0000-0000-000000000031', 'Grass Pollen Allergy', 'Environmental', 'Moderate', 'Hay fever, nasal congestion, sneezing', 'Grass pollen, Lawn mowing, Summer allergens', '2025-07-15T15:30:00+00:00'),
('20000001-0001-0001-0001-000000000032', '10000000-0000-0000-0000-000000000032', 'Oak Pollen Allergy', 'Environmental', 'Mild', 'Seasonal allergy symptoms, eye watering', 'Oak trees, Tree pollen, Spring allergens', '2025-08-20T08:45:00+00:00'),
('20000001-0001-0001-0001-000000000033', '10000000-0000-0000-0000-000000000033', 'Cockroach Allergy', 'Environmental', 'Moderate', 'Asthma symptoms, skin reactions', 'Cockroach debris, Urban environments', '2025-09-25T12:15:00+00:00'),
('20000001-0001-0001-0001-000000000034', '10000000-0000-0000-0000-000000000034', 'Horse Dander Allergy', 'Environmental', 'Moderate', 'Respiratory symptoms, skin reactions', 'Horse hair, Horse dander, Riding equipment', '2025-10-30T16:30:00+00:00'),
('20000001-0001-0001-0001-000000000035', '10000000-0000-0000-0000-000000000035', 'Rabbit Dander Allergy', 'Environmental', 'Mild', 'Sneezing, mild respiratory symptoms', 'Rabbit fur, Pet rabbits, Rabbit urine', '2025-11-15T09:00:00+00:00'),
('20000001-0001-0001-0001-000000000036', '10000000-0000-0000-0000-000000000036', 'Feather Allergy', 'Environmental', 'Mild', 'Respiratory symptoms, skin irritation', 'Down pillows, Feather bedding, Bird feathers', '2025-12-20T13:30:00+00:00'),
('20000001-0001-0001-0001-000000000037', '10000000-0000-0000-0000-000000000037', 'Wool Allergy', 'Contact', 'Mild', 'Contact dermatitis, itching, skin irritation', 'Wool clothing, Wool carpets, Lanolin', '2026-01-25T10:45:00+00:00'),
('20000001-0001-0001-0001-000000000038', '10000000-0000-0000-0000-000000000038', 'Rubber Allergy', 'Contact', 'Moderate', 'Contact dermatitis, skin swelling', 'Rubber gloves, Rubber bands, Tires', '2026-02-28T15:00:00+00:00'),
('20000001-0001-0001-0001-000000000039', '10000000-0000-0000-0000-000000000039', 'Adhesive Allergy', 'Contact', 'Mild', 'Skin rash at contact sites, itching', 'Medical tape, Band-aids, Adhesive products', '2026-03-15T11:15:00+00:00'),
('20000001-0001-0001-0001-000000000040', '10000000-0000-0000-0000-000000000040', 'Sun Allergy', 'Environmental', 'Moderate', 'Skin rash, burning, blistering after sun exposure', 'UV radiation, Sunlight, Photosensitizing medications', '2026-04-20T14:30:00+00:00'),
('20000001-0001-0001-0001-000000000041', '10000000-0000-0000-0000-000000000041', 'Cold Allergy', 'Physical', 'Mild', 'Hives, swelling when exposed to cold', 'Cold temperatures, Cold water, Wind', '2026-05-25T08:00:00+00:00'),
('20000001-0001-0001-0001-000000000042', '10000000-0000-0000-0000-000000000042', 'Exercise-Induced Allergy', 'Physical', 'Moderate', 'Hives, flushing, difficulty breathing during exercise', 'Physical exertion, Heat, Sweating', '2026-06-30T12:45:00+00:00'),
('20000001-0001-0001-0001-000000000043', '10000000-0000-0000-0000-000000000043', 'Water Allergy', 'Physical', 'Rare', 'Hives, itching upon contact with water', 'Water of any temperature, Humidity', '2026-07-15T16:15:00+00:00'),
('20000001-0001-0001-0001-000000000044', '10000000-0000-0000-0000-000000000044', 'Pressure Allergy', 'Physical', 'Mild', 'Delayed hives, swelling at pressure points', 'Tight clothing, Prolonged sitting, Carrying bags', '2026-08-20T09:30:00+00:00'),
('20000001-0001-0001-0001-000000000045', '10000000-0000-0000-0000-000000000045', 'Vibration Allergy', 'Physical', 'Mild', 'Localized swelling, hives from vibration', 'Power tools, Machinery, Vibrating devices', '2026-09-25T13:00:00+00:00'),
('20000001-0001-0001-0001-000000000046', '10000000-0000-0000-0000-000000000046', 'Alpha-gal Allergy', 'Food', 'Severe', 'Delayed allergic reaction to mammalian meat', 'Red meat, Pork, Lamb, Beef products', '2026-10-30T15:45:00+00:00'),
('20000001-0001-0001-0001-000000000047', '10000000-0000-0000-0000-000000000047', 'Yeast Allergy', 'Food', 'Moderate', 'Digestive issues, skin reactions', 'Bread, Beer, Wine, Fermented foods', '2026-11-15T10:15:00+00:00'),
('20000001-0001-0001-0001-000000000048', '10000000-0000-0000-0000-000000000048', 'Corn Allergy', 'Food', 'Moderate', 'Digestive problems, skin reactions', 'Corn, Corn syrup, Corn starch, Corn oil', '2026-12-20T14:00:00+00:00'),
('20000001-0001-0001-0001-000000000049', '10000000-0000-0000-0000-000000000049', 'Garlic Allergy', 'Food', 'Mild', 'Digestive upset, skin reactions', 'Garlic, Garlic powder, Foods containing garlic', '2027-01-25T11:30:00+00:00'),
('20000001-0001-0001-0001-000000000050', '10000000-0000-0000-0000-000000000050', 'Onion Allergy', 'Food', 'Mild', 'Digestive problems, eye irritation', 'Onions, Onion powder, Processed foods with onions', '2027-02-28T16:45:00+00:00');

-- Insert 50+ Different Medications across patient population
INSERT INTO "Medications" ("Id", "PatientId", "Name", "Dosage", "Frequency", "PrescribingDoctor", "StartDate", "EndDate") VALUES
-- Original patient medications
('11111111-1111-1111-aaaa-111111111111', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'Metformin', '500mg', 'Twice daily with meals', 'Dr. Sarah Johnson', '2023-01-15T00:00:00+00:00', NULL),
('11111111-1111-1111-aaaa-111111111112', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'Insulin Glargine', '20 units', 'Once daily at bedtime', 'Dr. Emily Rodriguez', '2023-06-01T00:00:00+00:00', NULL),
('22222222-2222-2222-bbbb-222222222222', 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'Lisinopril', '10mg', 'Once daily in morning', 'Dr. Michael Chen', '2023-02-01T00:00:00+00:00', NULL),
('22222222-2222-2222-bbbb-222222222223', 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'Hydrochlorothiazide', '25mg', 'Once daily in morning', 'Dr. Michael Chen', '2023-05-15T00:00:00+00:00', NULL),
('33333333-3333-3333-cccc-333333333333', 'cccccccc-cccc-cccc-cccc-cccccccccccc', 'Ibuprofen', '600mg', 'Three times daily with food', 'Dr. James Wilson', '2023-03-10T00:00:00+00:00', '2023-09-10T00:00:00+00:00'),
('33333333-3333-3333-cccc-333333333334', 'cccccccc-cccc-cccc-cccc-cccccccccccc', 'Glucosamine Sulfate', '1500mg', 'Once daily with breakfast', 'Dr. James Wilson', '2023-01-20T00:00:00+00:00', NULL),
('44444444-4444-4444-dddd-444444444444', 'dddddddd-dddd-dddd-dddd-dddddddddddd', 'Fluticasone Inhaler', '110mcg', 'Two puffs twice daily', 'Dr. Maria Garcia', '2023-01-05T00:00:00+00:00', NULL),
('44444444-4444-4444-dddd-444444444445', 'dddddddd-dddd-dddd-dddd-dddddddddddd', 'Albuterol Inhaler', '90mcg', 'As needed for wheezing', 'Dr. Maria Garcia', '2023-01-05T00:00:00+00:00', NULL),
('55555555-5555-5555-eeee-555555555555', 'eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', 'Enalapril', '5mg', 'Twice daily', 'Dr. David Brown', '2023-04-01T00:00:00+00:00', NULL),
('55555555-5555-5555-eeee-555555555556', 'eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', 'Calcium Carbonate', '1000mg', 'Three times daily with meals', 'Dr. David Brown', '2023-04-01T00:00:00+00:00', NULL),
('66666666-6666-6666-ffff-666666666666', 'ffffffff-ffff-ffff-ffff-ffffffffffff', 'Sertraline', '50mg', 'Once daily in morning', 'Dr. Lisa Thompson', '2023-03-01T00:00:00+00:00', NULL),
('66666666-6666-6666-ffff-666666666667', 'ffffffff-ffff-ffff-ffff-ffffffffffff', 'Lorazepam', '0.5mg', 'As needed for anxiety (max 3 times daily)', 'Dr. Lisa Thompson', '2023-03-01T00:00:00+00:00', NULL),

-- Additional 40+ medications for expanded patient population
('30000001-0001-0001-0001-000000000001', '10000000-0000-0000-0000-000000000001', 'Atorvastatin', '20mg', 'Once daily at bedtime', 'Dr. Michael Chen', '2024-01-15T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000002', '10000000-0000-0000-0000-000000000002', 'Levothyroxine', '100mcg', 'Once daily on empty stomach', 'Dr. Emily Rodriguez', '2024-02-20T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000003', '10000000-0000-0000-0000-000000000003', 'Omeprazole', '20mg', 'Once daily before breakfast', 'Dr. Jessica Martinez', '2024-03-25T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000004', '10000000-0000-0000-0000-000000000004', 'Methotrexate', '15mg', 'Once weekly', 'Dr. Daniel Anderson', '2024-04-30T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000005', '10000000-0000-0000-0000-000000000005', 'Tiotropium Inhaler', '18mcg', 'Once daily', 'Dr. Maria Garcia', '2024-05-15T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000006', '10000000-0000-0000-0000-000000000006', 'Escitalopram', '10mg', 'Once daily in morning', 'Dr. Lisa Thompson', '2024-06-20T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000007', '10000000-0000-0000-0000-000000000007', 'Warfarin', '5mg', 'Once daily at same time', 'Dr. Michael Chen', '2024-07-25T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000008', '10000000-0000-0000-0000-000000000008', 'Levothyroxine', '75mcg', 'Once daily on empty stomach', 'Dr. Emily Rodriguez', '2024-08-30T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000009', '10000000-0000-0000-0000-000000000009', 'Sumatriptan', '50mg', 'As needed for migraine', 'Dr. Christopher Taylor', '2024-09-15T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000010', '10000000-0000-0000-0000-000000000010', 'CPAP Therapy', 'Continuous', 'Nightly during sleep', 'Dr. Maria Garcia', '2024-10-20T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000011', '10000000-0000-0000-0000-000000000011', 'Alendronate', '70mg', 'Once weekly on empty stomach', 'Dr. James Wilson', '2024-11-25T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000012', '10000000-0000-0000-0000-000000000012', 'Dicyclomine', '20mg', 'Four times daily before meals', 'Dr. Jessica Martinez', '2024-12-30T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000013', '10000000-0000-0000-0000-000000000013', 'Lithium', '600mg', 'Twice daily with food', 'Dr. Lisa Thompson', '2025-01-15T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000014', '10000000-0000-0000-0000-000000000014', 'Gabapentin', '300mg', 'Three times daily', 'Dr. Christopher Taylor', '2025-02-20T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000015', '10000000-0000-0000-0000-000000000015', 'Clobetasol Cream', '0.05%', 'Apply twice daily to affected areas', 'Dr. Robert Kim', '2025-03-25T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000016', '10000000-0000-0000-0000-000000000016', 'Latanoprost Eye Drops', '0.005%', 'One drop each eye at bedtime', 'Dr. Steven Hall', '2025-04-30T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000017', '10000000-0000-0000-0000-000000000017', 'Modafinil', '200mg', 'Once daily in morning', 'Dr. Christopher Taylor', '2025-05-15T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000018', '10000000-0000-0000-0000-000000000018', 'Hydroxychloroquine', '200mg', 'Twice daily with food', 'Dr. Daniel Anderson', '2025-06-20T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000019', '10000000-0000-0000-0000-000000000019', 'Lamotrigine', '100mg', 'Twice daily', 'Dr. Christopher Taylor', '2025-07-25T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000020', '10000000-0000-0000-0000-000000000020', 'Ranibizumab Injection', '0.5mg', 'Monthly intravitreal injection', 'Dr. Steven Hall', '2025-08-30T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000021', '10000000-0000-0000-0000-000000000021', 'Tamsulosin', '0.4mg', 'Once daily 30 minutes after meal', 'Dr. Thomas Lewis', '2025-09-15T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000022', '10000000-0000-0000-0000-000000000022', 'Estradiol Patch', '0.1mg', 'Change twice weekly', 'Dr. Rachel Walker', '2025-10-20T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000023', '10000000-0000-0000-0000-000000000023', 'Prednisone', '10mg', 'Once daily with food', 'Dr. Daniel Anderson', '2025-11-25T00:00:00+00:00', '2026-02-25T00:00:00+00:00'),
('30000001-0001-0001-0001-000000000024', '10000000-0000-0000-0000-000000000024', 'Vitamin D3', '2000 IU', 'Once daily with fat-containing meal', 'Dr. Sarah Johnson', '2025-12-30T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000025', '10000000-0000-0000-0000-000000000025', 'Fluticasone Nasal Spray', '50mcg', 'Two sprays each nostril daily', 'Dr. Maria Garcia', '2026-01-15T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000026', '10000000-0000-0000-0000-000000000026', 'Allopurinol', '300mg', 'Once daily with plenty of water', 'Dr. Daniel Anderson', '2026-02-20T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000027', '10000000-0000-0000-0000-000000000027', 'Ropinirole', '2mg', 'Three times daily', 'Dr. Christopher Taylor', '2026-03-25T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000028', '10000000-0000-0000-0000-000000000028', 'Metformin', '1000mg', 'Twice daily with meals', 'Dr. Emily Rodriguez', '2026-04-30T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000029', '10000000-0000-0000-0000-000000000029', 'Mesalamine', '800mg', 'Three times daily with food', 'Dr. Jessica Martinez', '2026-05-15T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000030', '10000000-0000-0000-0000-000000000030', 'Hydrocortisone Cream', '1%', 'Apply to affected areas twice daily', 'Dr. Robert Kim', '2026-06-20T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000031', '10000000-0000-0000-0000-000000000031', 'Amlodipine', '5mg', 'Once daily', 'Dr. Michael Chen', '2026-07-25T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000032', '10000000-0000-0000-0000-000000000032', 'Simvastatin', '20mg', 'Once daily at bedtime', 'Dr. Michael Chen', '2026-08-30T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000033', '10000000-0000-0000-0000-000000000033', 'Pantoprazole', '40mg', 'Once daily before breakfast', 'Dr. Jessica Martinez', '2026-09-15T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000034', '10000000-0000-0000-0000-000000000034', 'Montelukast', '10mg', 'Once daily at bedtime', 'Dr. Maria Garcia', '2026-10-20T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000035', '10000000-0000-0000-0000-000000000035', 'Trazodone', '50mg', 'Once daily at bedtime', 'Dr. Lisa Thompson', '2026-11-25T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000036', '10000000-0000-0000-0000-000000000036', 'Duloxetine', '60mg', 'Once daily', 'Dr. Lisa Thompson', '2026-12-30T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000037', '10000000-0000-0000-0000-000000000037', 'Losartan', '50mg', 'Once daily', 'Dr. Michael Chen', '2027-01-15T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000038', '10000000-0000-0000-0000-000000000038', 'Furosemide', '40mg', 'Once daily in morning', 'Dr. Michael Chen', '2027-02-20T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000039', '10000000-0000-0000-0000-000000000039', 'Aspirin', '81mg', 'Once daily with food', 'Dr. Michael Chen', '2027-03-25T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000040', '10000000-0000-0000-0000-000000000040', 'Clopidogrel', '75mg', 'Once daily', 'Dr. Michael Chen', '2027-04-30T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000041', '10000000-0000-0000-0000-000000000041', 'Insulin Lispro', '15 units', 'Three times daily before meals', 'Dr. Emily Rodriguez', '2027-05-15T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000042', '10000000-0000-0000-0000-000000000042', 'Glipizide', '5mg', 'Twice daily before meals', 'Dr. Emily Rodriguez', '2027-06-20T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000043', '10000000-0000-0000-0000-000000000043', 'Spironolactone', '25mg', 'Once daily with food', 'Dr. Michael Chen', '2027-07-25T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000044', '10000000-0000-0000-0000-000000000044', 'Prochlorperazine', '5mg', 'Three times daily as needed', 'Dr. Kevin Harris', '2027-08-30T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000045', '10000000-0000-0000-0000-000000000045', 'Celecoxib', '200mg', 'Once daily with food', 'Dr. James Wilson', '2027-09-15T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000046', '10000000-0000-0000-0000-000000000046', 'Tramadol', '50mg', 'Every 6 hours as needed for pain', 'Dr. James Wilson', '2027-10-20T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000047', '10000000-0000-0000-0000-000000000047', 'Carbamazepine', '200mg', 'Twice daily with food', 'Dr. Christopher Taylor', '2027-11-25T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000048', '10000000-0000-0000-0000-000000000048', 'Donepezil', '10mg', 'Once daily at bedtime', 'Dr. Christopher Taylor', '2027-12-30T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000049', '10000000-0000-0000-0000-000000000049', 'Rivaroxaban', '20mg', 'Once daily with evening meal', 'Dr. Michael Chen', '2028-01-15T00:00:00+00:00', NULL),
('30000001-0001-0001-0001-000000000050', '10000000-0000-0000-0000-000000000050', 'Budesonide Inhaler', '160mcg', 'Two puffs twice daily', 'Dr. Maria Garcia', '2028-02-20T00:00:00+00:00', NULL);

-- Insert 50+ Different Diagnoses across patient population
INSERT INTO "Diagnoses" ("Id", "PatientId", "Code", "Description", "Severity", "DiagnosedOn", "PrescribingDoctor", "Notes") VALUES
-- Original patient diagnoses
('11111111-1111-1111-1111-aaaa11111111', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'E11.9', 'Type 2 diabetes mellitus without complications', 'Moderate', '2023-01-15T10:30:00+00:00', 'Dr. Sarah Johnson', 'HbA1c 8.2%, requires medication management and lifestyle modifications'),
('11111111-1111-1111-1111-aaaa11111112', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'Z87.891', 'Personal history of nicotine dependence', 'Mild', '2023-01-15T10:30:00+00:00', 'Dr. Sarah Johnson', 'Former smoker, quit 2 years ago, no current tobacco use'),
('22222222-2222-2222-2222-bbbb22222222', 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'I10', 'Essential hypertension', 'Mild', '2023-02-01T14:15:00+00:00', 'Dr. Michael Chen', 'Blood pressure 145/92, well controlled with medication'),
('22222222-2222-2222-2222-bbbb22222223', 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'E78.5', 'Hyperlipidemia, unspecified', 'Mild', '2023-02-01T14:15:00+00:00', 'Dr. Michael Chen', 'Total cholesterol 240 mg/dL, LDL 165 mg/dL'),
('33333333-3333-3333-3333-cccc33333333', 'cccccccc-cccc-cccc-cccc-cccccccccccc', 'M17.9', 'Osteoarthritis of knee, unspecified', 'Moderate', '2023-03-10T11:00:00+00:00', 'Dr. James Wilson', 'Bilateral knee pain, limited range of motion, X-ray shows joint space narrowing'),
('44444444-4444-4444-4444-dddd44444444', 'dddddddd-dddd-dddd-dddd-dddddddddddd', 'J45.9', 'Asthma, unspecified', 'Mild', '2023-01-05T09:45:00+00:00', 'Dr. Maria Garcia', 'Well-controlled asthma with inhaled corticosteroids'),
('44444444-4444-4444-4444-dddd44444445', 'dddddddd-dddd-dddd-dddd-dddddddddddd', 'J30.9', 'Allergic rhinitis, unspecified', 'Mild', '2023-01-05T09:45:00+00:00', 'Dr. Maria Garcia', 'Seasonal allergies, responds well to antihistamines'),
('55555555-5555-5555-5555-eeee55555555', 'eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', 'N18.3', 'Chronic kidney disease, stage 3 (moderate)', 'Moderate', '2023-04-01T13:20:00+00:00', 'Dr. David Brown', 'eGFR 45 mL/min/1.73m², requires regular monitoring'),
('55555555-5555-5555-5555-eeee55555556', 'eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', 'E83.52', 'Hypercalcemia', 'Mild', '2023-04-01T13:20:00+00:00', 'Dr. David Brown', 'Serum calcium 10.8 mg/dL, related to CKD'),
('66666666-6666-6666-6666-ffff66666666', 'ffffffff-ffff-ffff-ffff-ffffffffffff', 'F41.1', 'Generalized anxiety disorder', 'Moderate', '2023-03-01T15:30:00+00:00', 'Dr. Lisa Thompson', 'GAD-7 score 12, responds well to SSRI therapy'),
('66666666-6666-6666-6666-ffff66666667', 'ffffffff-ffff-ffff-ffff-ffffffffffff', 'G47.00', 'Insomnia, unspecified', 'Mild', '2023-03-01T15:30:00+00:00', 'Dr. Lisa Thompson', 'Sleep disturbances related to anxiety, improving with treatment'),

-- Additional 40+ diagnoses for expanded patient population
('40000001-0001-0001-0001-000000000001', '10000000-0000-0000-0000-000000000001', 'I25.10', 'Atherosclerotic heart disease of native coronary artery without angina pectoris', 'Severe', '2024-01-15T10:00:00+00:00', 'Dr. Michael Chen', 'Coronary angiography shows 70% LAD stenosis, scheduled for PCI'),
('40000001-0001-0001-0001-000000000002', '10000000-0000-0000-0000-000000000002', 'M79.3', 'Panniculitis, unspecified', 'Moderate', '2024-02-20T14:30:00+00:00', 'Dr. Daniel Anderson', 'Chronic widespread pain, tender points positive, meets ACR criteria'),
('40000001-0001-0001-0001-000000000003', '10000000-0000-0000-0000-000000000003', 'K21.9', 'Gastro-esophageal reflux disease without esophagitis', 'Mild', '2024-03-25T11:15:00+00:00', 'Dr. Jessica Martinez', 'Responds well to PPI therapy, lifestyle modifications recommended'),
('40000001-0001-0001-0001-000000000004', '10000000-0000-0000-0000-000000000004', 'M06.9', 'Rheumatoid arthritis, unspecified', 'Moderate', '2024-04-30T09:45:00+00:00', 'Dr. Daniel Anderson', 'RF positive, anti-CCP positive, started on methotrexate'),
('40000001-0001-0001-0001-000000000005', '10000000-0000-0000-0000-000000000005', 'J44.1', 'Chronic obstructive pulmonary disease with acute exacerbation', 'Moderate', '2024-05-15T16:20:00+00:00', 'Dr. Maria Garcia', 'FEV1 55% predicted, GOLD stage 2, smoking cessation counseled'),
('40000001-0001-0001-0001-000000000006', '10000000-0000-0000-0000-000000000006', 'F33.1', 'Major depressive disorder, recurrent, moderate', 'Moderate', '2024-06-20T13:00:00+00:00', 'Dr. Lisa Thompson', 'PHQ-9 score 14, started on escitalopram, therapy referral'),
('40000001-0001-0001-0001-000000000007', '10000000-0000-0000-0000-000000000007', 'I48.91', 'Unspecified atrial fibrillation', 'Moderate', '2024-07-25T10:30:00+00:00', 'Dr. Michael Chen', 'New onset AFib, CHA2DS2-VASc score 3, anticoagulation started'),
('40000001-0001-0001-0001-000000000008', '10000000-0000-0000-0000-000000000008', 'E03.9', 'Hypothyroidism, unspecified', 'Mild', '2024-08-30T15:45:00+00:00', 'Dr. Emily Rodriguez', 'TSH 8.5 mIU/L, started on levothyroxine replacement'),
('40000001-0001-0001-0001-000000000009', '10000000-0000-0000-0000-000000000009', 'G43.909', 'Migraine, unspecified, not intractable, without status migrainosus', 'Moderate', '2024-09-15T12:15:00+00:00', 'Dr. Christopher Taylor', 'Episodic migraine, 3-4 episodes per month, prophylaxis considered'),
('40000001-0001-0001-0001-000000000010', '10000000-0000-0000-0000-000000000010', 'G47.33', 'Obstructive sleep apnea (adult) (pediatric)', 'Moderate', '2024-10-20T08:00:00+00:00', 'Dr. Maria Garcia', 'AHI 25/hour, moderate OSA, CPAP therapy initiated'),
('40000001-0001-0001-0001-000000000011', '10000000-0000-0000-0000-000000000011', 'M81.0', 'Age-related osteoporosis without current pathological fracture', 'Moderate', '2024-11-25T14:30:00+00:00', 'Dr. James Wilson', 'DEXA scan T-score -2.8, bisphosphonate therapy started'),
('40000001-0001-0001-0001-000000000012', '10000000-0000-0000-0000-000000000012', 'K58.9', 'Irritable bowel syndrome without diarrhea', 'Mild', '2024-12-30T11:00:00+00:00', 'Dr. Jessica Martinez', 'Rome IV criteria met, dietary modifications and probiotics recommended'),
('40000001-0001-0001-0001-000000000013', '10000000-0000-0000-0000-000000000013', 'F31.81', 'Bipolar II disorder', 'Moderate', '2025-01-15T16:45:00+00:00', 'Dr. Lisa Thompson', 'Hypomanic episodes with major depression, mood stabilizer initiated'),
('40000001-0001-0001-0001-000000000014', '10000000-0000-0000-0000-000000000014', 'G62.9', 'Polyneuropathy, unspecified', 'Moderate', '2025-02-20T09:30:00+00:00', 'Dr. Christopher Taylor', 'Distal symmetric sensorimotor neuropathy, likely diabetic'),
('40000001-0001-0001-0001-000000000015', '10000000-0000-0000-0000-000000000015', 'L40.9', 'Psoriasis, unspecified', 'Mild', '2025-03-25T13:15:00+00:00', 'Dr. Robert Kim', 'Plaque psoriasis affecting 5% BSA, topical therapy effective'),
('40000001-0001-0001-0001-000000000016', '10000000-0000-0000-0000-000000000016', 'H40.10X1', 'Unspecified open-angle glaucoma, right eye, stage 1', 'Mild', '2025-04-30T10:45:00+00:00', 'Dr. Steven Hall', 'IOP 24 mmHg, early visual field defects, topical therapy started'),
('40000001-0001-0001-0001-000000000017', '10000000-0000-0000-0000-000000000017', 'G93.3', 'Postviral fatigue syndrome', 'Moderate', '2025-05-15T15:00:00+00:00', 'Dr. Patricia White', 'Post-COVID fatigue syndrome, gradual activity increase plan'),
('40000001-0001-0001-0001-000000000018', '10000000-0000-0000-0000-000000000018', 'M32.9', 'Systemic lupus erythematosus, unspecified', 'Moderate', '2025-06-20T12:30:00+00:00', 'Dr. Daniel Anderson', 'ANA positive 1:320, anti-dsDNA positive, hydroxychloroquine started'),
('40000001-0001-0001-0001-000000000019', '10000000-0000-0000-0000-000000000019', 'G40.909', 'Epilepsy, unspecified, not intractable, without status epilepticus', 'Moderate', '2025-07-25T08:15:00+00:00', 'Dr. Christopher Taylor', 'Generalized tonic-clonic seizures, well controlled on lamotrigine'),
('40000001-0001-0001-0001-000000000020', '10000000-0000-0000-0000-000000000020', 'H25.9', 'Unspecified age-related cataract', 'Mild', '2025-08-30T14:45:00+00:00', 'Dr. Steven Hall', 'Bilateral cataracts, vision 20/40, surgery planned when vision worsens'),
('40000001-0001-0001-0001-000000000021', '10000000-0000-0000-0000-000000000021', 'N40.1', 'Benign prostatic hyperplasia with lower urinary tract symptoms', 'Mild', '2025-09-15T11:30:00+00:00', 'Dr. Thomas Lewis', 'IPSS score 12, alpha-blocker therapy initiated'),
('40000001-0001-0001-0001-000000000022', '10000000-0000-0000-0000-000000000022', 'N80.9', 'Endometriosis, unspecified', 'Moderate', '2025-10-20T16:00:00+00:00', 'Dr. Rachel Walker', 'Laparoscopy confirmed endometriosis, hormonal therapy recommended'),
('40000001-0001-0001-0001-000000000023', '10000000-0000-0000-0000-000000000023', 'K90.0', 'Celiac disease', 'Moderate', '2025-11-25T09:00:00+00:00', 'Dr. Jessica Martinez', 'Positive tissue transglutaminase, biopsy confirmed, gluten-free diet'),
('40000001-0001-0001-0001-000000000024', '10000000-0000-0000-0000-000000000024', 'H35.31', 'Nonexudative age-related macular degeneration, right eye', 'Moderate', '2025-12-30T13:45:00+00:00', 'Dr. Steven Hall', 'Drusen and RPE changes, AREDS vitamins recommended'),
('40000001-0001-0001-0001-000000000025', '10000000-0000-0000-0000-000000000025', 'J32.9', 'Chronic sinusitis, unspecified', 'Mild', '2026-01-15T10:15:00+00:00', 'Dr. Maria Garcia', 'CT shows mucosal thickening, medical management effective'),
('40000001-0001-0001-0001-000000000026', '10000000-0000-0000-0000-000000000026', 'M10.9', 'Gout, unspecified', 'Moderate', '2026-02-20T15:30:00+00:00', 'Dr. Daniel Anderson', 'Recurrent acute gout attacks, uric acid 9.2 mg/dL, allopurinol started'),
('40000001-0001-0001-0001-000000000027', '10000000-0000-0000-0000-000000000027', 'G25.81', 'Restless legs syndrome', 'Mild', '2026-03-25T12:00:00+00:00', 'Dr. Christopher Taylor', 'Evening leg discomfort, dopamine agonist therapy considered'),
('40000001-0001-0001-0001-000000000028', '10000000-0000-0000-0000-000000000028', 'E28.2', 'Polycystic ovarian syndrome', 'Moderate', '2026-04-30T08:45:00+00:00', 'Dr. Rachel Walker', 'Rotterdam criteria met, metformin and lifestyle modifications'),
('40000001-0001-0001-0001-000000000029', '10000000-0000-0000-0000-000000000029', 'K57.92', 'Diverticulitis of intestine, part unspecified, without perforation or abscess without bleeding', 'Moderate', '2026-05-15T14:15:00+00:00', 'Dr. Jessica Martinez', 'CT confirmed sigmoid diverticulitis, antibiotics and dietary changes'),
('40000001-0001-0001-0001-000000000030', '10000000-0000-0000-0000-000000000030', 'L20.9', 'Atopic dermatitis, unspecified', 'Mild', '2026-06-20T11:45:00+00:00', 'Dr. Robert Kim', 'Chronic eczema, topical corticosteroids and moisturizers effective'),
('40000001-0001-0001-0001-000000000031', '10000000-0000-0000-0000-000000000031', 'I35.0', 'Nonrheumatic aortic (valve) stenosis', 'Moderate', '2026-07-25T16:30:00+00:00', 'Dr. Michael Chen', 'Echo shows moderate AS, valve area 1.2 cm², annual monitoring'),
('40000001-0001-0001-0001-000000000032', '10000000-0000-0000-0000-000000000032', 'N39.0', 'Urinary tract infection, site not specified', 'Mild', '2026-08-30T09:15:00+00:00', 'Dr. Michelle Clark', 'Recurrent UTIs, completed antibiotic course, preventive measures discussed'),
('40000001-0001-0001-0001-000000000033', '10000000-0000-0000-0000-000000000033', 'M54.5', 'Low back pain', 'Moderate', '2026-09-15T13:30:00+00:00', 'Dr. James Wilson', 'Chronic low back pain, MRI shows disc degeneration L4-L5'),
('40000001-0001-0001-0001-000000000034', '10000000-0000-0000-0000-000000000034', 'E66.9', 'Obesity, unspecified', 'Moderate', '2026-10-20T10:00:00+00:00', 'Dr. Michelle Clark', 'BMI 32.5, metabolic syndrome present, weight management program'),
('40000001-0001-0001-0001-000000000035', '10000000-0000-0000-0000-000000000035', 'F51.01', 'Primary insomnia', 'Mild', '2026-11-25T15:45:00+00:00', 'Dr. Lisa Thompson', 'Sleep hygiene education, cognitive behavioral therapy for insomnia'),
('40000001-0001-0001-0001-000000000036', '10000000-0000-0000-0000-000000000036', 'K21.0', 'Gastro-esophageal reflux disease with esophagitis', 'Moderate', '2026-12-30T12:15:00+00:00', 'Dr. Jessica Martinez', 'Endoscopy shows grade B esophagitis, PPI therapy optimized'),
('40000001-0001-0001-0001-000000000037', '10000000-0000-0000-0000-000000000037', 'I50.9', 'Heart failure, unspecified', 'Moderate', '2027-01-15T08:30:00+00:00', 'Dr. Michael Chen', 'EF 40%, HFrEF, ACE inhibitor and beta-blocker initiated'),
('40000001-0001-0001-0001-000000000038', '10000000-0000-0000-0000-000000000038', 'J45.0', 'Allergic asthma', 'Mild', '2027-02-20T14:00:00+00:00', 'Dr. Maria Garcia', 'Allergic asthma well controlled, allergen avoidance counseled'),
('40000001-0001-0001-0001-000000000039', '10000000-0000-0000-0000-000000000039', 'D50.9', 'Iron deficiency anemia, unspecified', 'Mild', '2027-03-25T11:30:00+00:00', 'Dr. Michelle Clark', 'Hemoglobin 9.8 g/dL, iron supplementation started, GI evaluation planned'),
('40000001-0001-0001-0001-000000000040', '10000000-0000-0000-0000-000000000040', 'M79.1', 'Myalgia', 'Mild', '2027-04-30T16:15:00+00:00', 'Dr. James Wilson', 'Generalized muscle pain, likely statin-related, temporary discontinuation'),
('40000001-0001-0001-0001-000000000041', '10000000-0000-0000-0000-000000000041', 'H52.4', 'Presbyopia', 'Mild', '2027-05-15T09:45:00+00:00', 'Dr. Steven Hall', 'Age-related near vision decline, reading glasses prescribed'),
('40000001-0001-0001-0001-000000000042', '10000000-0000-0000-0000-000000000042', 'Z51.11', 'Encounter for antineoplastic chemotherapy', 'Severe', '2027-06-20T13:00:00+00:00', 'Dr. Amanda Lee', 'Breast cancer stage IIIA, adjuvant chemotherapy cycle 3 of 6'),
('40000001-0001-0001-0001-000000000043', '10000000-0000-0000-0000-000000000043', 'F32.1', 'Major depressive disorder, single episode, moderate', 'Moderate', '2027-07-25T15:30:00+00:00', 'Dr. Lisa Thompson', 'First episode depression, PHQ-9 score 16, antidepressant therapy'),
('40000001-0001-0001-0001-000000000044', '10000000-0000-0000-0000-000000000044', 'I25.2', 'Old myocardial infarction', 'Moderate', '2027-08-30T10:15:00+00:00', 'Dr. Michael Chen', 'History of STEMI 2 years ago, on optimal medical therapy'),
('40000001-0001-0001-0001-000000000045', '10000000-0000-0000-0000-000000000045', 'M25.511', 'Pain in right shoulder', 'Mild', '2027-09-15T12:45:00+00:00', 'Dr. James Wilson', 'Rotator cuff tendinopathy, physical therapy and NSAIDs'),
('40000001-0001-0001-0001-000000000046', '10000000-0000-0000-0000-000000000046', 'B02.9', 'Zoster without complications', 'Moderate', '2027-10-20T14:30:00+00:00', 'Dr. Robert Kim', 'Herpes zoster T6 dermatome, antiviral therapy within 72 hours'),
('40000001-0001-0001-0001-000000000047', '10000000-0000-0000-0000-000000000047', 'F03.90', 'Unspecified dementia without behavioral disturbance', 'Moderate', '2027-11-25T08:00:00+00:00', 'Dr. Christopher Taylor', 'Progressive cognitive decline, MMSE 18/30, cholinesterase inhibitor started'),
('40000001-0001-0001-0001-000000000048', '10000000-0000-0000-0000-000000000048', 'I73.9', 'Peripheral vascular disease, unspecified', 'Moderate', '2027-12-30T16:45:00+00:00', 'Dr. Michael Chen', 'Claudication symptoms, ABI 0.7, antiplatelet therapy and walking program'),
('40000001-0001-0001-0001-000000000049', '10000000-0000-0000-0000-000000000049', 'K80.20', 'Calculus of gallbladder without cholecystitis without obstruction', 'Mild', '2028-01-15T11:15:00+00:00', 'Dr. Jessica Martinez', 'Incidental gallstones on imaging, asymptomatic, conservative management'),
('40000001-0001-0001-0001-000000000050', '10000000-0000-0000-0000-000000000050', 'G35', 'Multiple sclerosis', 'Moderate', '2028-02-20T13:45:00+00:00', 'Dr. Christopher Taylor', 'Relapsing-remitting MS, oligoclonal bands positive, disease-modifying therapy');

-- Insert Appointments (sample appointments for key patients)
INSERT INTO "Appointments" ("Id", "PatientId", "AppointmentDate", "DoctorName", "Notes") VALUES
-- Original patient appointments maintained
('11111111-1111-1111-1111-1111aaaaaaaa', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', '2024-01-15T10:00:00+00:00', 'Dr. Sarah Johnson', 'Routine diabetes follow-up. HbA1c improved to 7.8%. Continue current medications. Discussed importance of diet and exercise.'),
('11111111-1111-1111-1111-1111aaaaaaab', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', '2024-02-20T14:30:00+00:00', 'Dr. Emily Rodriguez', 'Endocrinology consultation. Insulin dosage adjustment. Blood glucose logs reviewed. Good compliance with treatment plan.'),
('22222222-2222-2222-2222-2222bbbbbbbb', 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', '2024-01-10T09:15:00+00:00', 'Dr. Michael Chen', 'Cardiology follow-up. Blood pressure well controlled at 125/78. Continue current antihypertensive regimen. Annual EKG normal.'),
('22222222-2222-2222-2222-2222bbbbbbbc', 'bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', '2024-03-05T11:00:00+00:00', 'Dr. Michael Chen', 'Lipid panel follow-up. Started statin therapy. Discussed dietary modifications and exercise program.'),
('33333333-3333-3333-3333-3333cccccccc', 'cccccccc-cccc-cccc-cccc-cccccccccccc', '2024-02-15T08:45:00+00:00', 'Dr. James Wilson', 'Orthopedic evaluation. Knee pain stable. Physical therapy showing good results. Discussed potential for steroid injection.'),
('33333333-3333-3333-3333-3333cccccccb', 'cccccccc-cccc-cccc-cccc-cccccccccccc', '2024-04-20T13:30:00+00:00', 'Dr. James Wilson', 'Follow-up post knee injection. Significant pain improvement. Continue physical therapy and weight management program.'),

-- Additional appointments for expanded patient base (sample)
('50000001-0001-0001-0001-000000000001', '10000000-0000-0000-0000-000000000001', '2024-01-25T10:30:00+00:00', 'Dr. Michael Chen', 'Cardiac catheterization follow-up. Stent placement successful. Dual antiplatelet therapy initiated. Cardiac rehabilitation referral.'),
('50000001-0001-0001-0001-000000000002', '10000000-0000-0000-0000-000000000002', '2024-02-28T14:15:00+00:00', 'Dr. Daniel Anderson', 'Rheumatology consultation. Fibromyalgia diagnosis confirmed. Pain management plan established. Exercise therapy recommended.'),
('50000001-0001-0001-0001-000000000003', '10000000-0000-0000-0000-000000000003', '2024-03-20T11:45:00+00:00', 'Dr. Jessica Martinez', 'GI follow-up. GERD symptoms improved on PPI therapy. Lifestyle modifications showing benefit. Continue current treatment.'),
('50000001-0001-0001-0001-000000000004', '10000000-0000-0000-0000-000000000004', '2024-04-15T09:30:00+00:00', 'Dr. Daniel Anderson', 'Rheumatoid arthritis monitoring. Joint pain improved on methotrexate. Laboratory values stable. Continue current regimen.'),
('50000001-0001-0001-0001-000000000005', '10000000-0000-0000-0000-000000000005', '2024-05-22T16:00:00+00:00', 'Dr. Maria Garcia', 'COPD exacerbation follow-up. Symptoms resolved. Inhaler technique reviewed. Smoking cessation counseling provided.');

-- Insert Clinical Notes (comprehensive sample)
INSERT INTO "ClinicalNotes" ("Id", "PatientId", "OriginalText", "Summary", "CreatedAt") VALUES
-- Original detailed clinical notes maintained
('11111111-1111-1111-1111-1111-1111111a', 'aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 
'CHIEF COMPLAINT: Follow-up for diabetes management.

HISTORY OF PRESENT ILLNESS: 
48-year-old male with Type 2 diabetes mellitus presents for routine follow-up. Patient reports good adherence to metformin 500mg twice daily. Blood glucose readings have been ranging 120-160 mg/dL fasting. No episodes of hypoglycemia. Patient has been working with nutritionist and reports 8-pound weight loss over past 3 months. Denies polyuria, polydipsia, or polyphagia. No visual changes, numbness, or tingling in extremities.

REVIEW OF SYSTEMS: 
Constitutional: No fever, chills, or night sweats. Denies fatigue.
Cardiovascular: No chest pain, palpitations, or shortness of breath.
Neurological: No headaches, dizziness, or peripheral neuropathy symptoms.

PHYSICAL EXAMINATION:
Vital Signs: BP 132/84, HR 76, Temp 98.6°F, Weight 185 lbs (down from 193 lbs)
General: Well-appearing male in no acute distress
HEENT: Normal
Cardiovascular: Regular rate and rhythm, no murmurs
Pulmonary: Clear to auscultation bilaterally
Extremities: No pedal edema, good pedal pulses, no diabetic foot ulcers

ASSESSMENT AND PLAN:
Type 2 diabetes mellitus - well controlled with current regimen
- Continue metformin 500mg BID
- HbA1c improved from 8.2% to 7.8%
- Continue dietary modifications and exercise program
- Diabetic foot exam normal
- Return in 3 months for follow-up
- Annual ophthalmology exam scheduled',
'48-year-old male with Type 2 diabetes mellitus showing good control on metformin. HbA1c improved to 7.8%. 8-pound weight loss achieved through diet and exercise. No diabetic complications noted. Continue current management plan with 3-month follow-up.',
'2024-01-15T10:30:00+00:00'),

-- Additional clinical notes for expanded patient base
('60000001-0001-0001-0001-000000000001', '10000000-0000-0000-0000-000000000001',
'CHIEF COMPLAINT: Chest pain and shortness of breath.

HISTORY OF PRESENT ILLNESS:
65-year-old male with history of hypertension and hyperlipidemia presents with 2-week history of exertional chest pressure. Pain is substernal, radiates to left arm, and is associated with mild dyspnea. Symptoms occur with walking 2 blocks and resolve with rest. No orthopnea or PND. No recent weight gain or lower extremity edema.

PAST MEDICAL HISTORY:
- Hypertension x 10 years
- Hyperlipidemia x 5 years
- Ex-smoker (quit 5 years ago, 30 pack-year history)

PHYSICAL EXAMINATION:
Vital Signs: BP 155/92, HR 88, RR 16, O2 sat 96% RA
Cardiovascular: Regular rate and rhythm, no murmurs, rubs, or gallops
Pulmonary: Clear to auscultation bilaterally
Extremities: No peripheral edema

DIAGNOSTIC STUDIES:
EKG: Sinus rhythm, no acute ST changes
Chest X-ray: Clear lungs, normal cardiac silhouette
Troponin: Negative x3
Stress test: Positive for reversible ischemia in LAD territory

ASSESSMENT AND PLAN:
Unstable angina with positive stress test
- Cardiac catheterization scheduled
- Started on dual antiplatelet therapy
- Optimize medical management with beta-blocker and ACE inhibitor
- Statin therapy intensified',
'65-year-old male with unstable angina and positive stress test showing LAD ischemia. Cardiac catheterization scheduled. Optimized medical therapy with dual antiplatelets, beta-blocker, and intensified statin therapy.',
'2024-01-25T14:30:00+00:00'),

('60000001-0001-0001-0001-000000000002', '10000000-0000-0000-0000-000000000002',
'CHIEF COMPLAINT: Widespread body pain and fatigue.

HISTORY OF PRESENT ILLNESS:
42-year-old female presents with 6-month history of widespread musculoskeletal pain and profound fatigue. Pain is described as aching and burning, affecting neck, shoulders, back, and extremities. Sleep is poor with frequent awakening. Cognitive difficulties with concentration and memory. No joint swelling or morning stiffness. Previous extensive workup including labs and imaging unrevealing.

PHYSICAL EXAMINATION:
Vital Signs: Normal
General: Appears fatigued but alert
Musculoskeletal: 18/18 tender points positive, no joint swelling or deformity
Neurological: Normal except for mild cognitive slowing

LABORATORY RESULTS:
ESR, CRP: Normal
ANA, RF: Negative
Thyroid function: Normal
Vitamin D: Low at 18 ng/mL

ASSESSMENT AND PLAN:
Fibromyalgia syndrome
- Patient education about condition
- Started on duloxetine 30mg daily
- Vitamin D supplementation
- Graduated exercise program
- Sleep hygiene counseling
- Referral to pain management',
'42-year-old female diagnosed with fibromyalgia syndrome based on clinical criteria. Started duloxetine, vitamin D supplementation, and comprehensive pain management approach including exercise and sleep hygiene.',
'2024-02-28T16:15:00+00:00'),

('60000001-0001-0001-0001-000000000003', '10000000-0000-0000-0000-000000000003',
'CHIEF COMPLAINT: Heartburn and acid regurgitation.

HISTORY OF PRESENT ILLNESS:
38-year-old male presents with 4-month history of heartburn and acid regurgitation occurring 3-4 times per week. Symptoms are worse after large meals and when lying down. Associated with mild dysphagia to solids. Antacids provide temporary relief. No weight loss, hematemesis, or melena. No family history of GI malignancy.

PHYSICAL EXAMINATION:
Vital Signs: Normal
General: Well-appearing male
Abdomen: Soft, non-tender, no masses
No lymphadenopathy

ASSESSMENT AND PLAN:
Gastroesophageal reflux disease (GERD)
- Trial of omeprazole 20mg daily before breakfast
- Dietary modifications: avoid trigger foods, smaller meals
- Elevate head of bed
- Weight loss counseling (BMI 28)
- Follow-up in 6 weeks
- Consider upper endoscopy if symptoms persist',
'38-year-old male with typical GERD symptoms. Started PPI therapy with lifestyle modifications including dietary changes and weight loss. Follow-up planned to assess response.',
'2024-03-20T11:45:00+00:00');

-- Verify the comprehensive data was inserted successfully
SELECT 'Medical Providers' as Table_Name, COUNT(*) as Row_Count FROM "MedicalProviders"
UNION ALL
SELECT 'Patients', COUNT(*) FROM "Patients"
UNION ALL
SELECT 'Medical Conditions', COUNT(*) FROM "MedicalConditions"
UNION ALL
SELECT 'Allergies', COUNT(*) FROM "Allergies"
UNION ALL
SELECT 'Medications', COUNT(*) FROM "Medications"
UNION ALL
SELECT 'Diagnoses', COUNT(*) FROM "Diagnoses"
UNION ALL
SELECT 'Appointments', COUNT(*) FROM "Appointments"
UNION ALL
SELECT 'Clinical Notes', COUNT(*) FROM "ClinicalNotes";
