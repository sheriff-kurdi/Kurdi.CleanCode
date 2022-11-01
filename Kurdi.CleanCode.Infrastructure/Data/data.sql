INSERT INTO "languages" ("language_code", "language_name") VALUES
                                                               ('en',	'English'),
                                                               ('ar',	'Arabic');

INSERT INTO "stock_items" ("sku", "supplier_identity", "available_stock", "cost_price", "discount", "is_discounted", "reserved_stock", "selling_price", "total_stock", "category") VALUES
                                                                                                                                                                                            ('1',	1,	1500,	80,	2,	'1',	0,	130,	1500,	NULL),
                                                                                                                                                                                            ('2',	1,	1300,	90,	12,	'1',	0,	140,	1500,	NULL);

INSERT INTO "stock_items_details" ("description", "name", "sku", "language_code") VALUES
                                                                                      ('الوصف 1',	'الاسم 1',	'1',	'ar'),
                                                                                      ('desc 1',	'name 1',	'1',	'en'),
                                                                                      ('الوصف 2',	'الاسم 2',	'2',	'ar'),
                                                                                      ('desc 2',	'name 2',	'2',	'en');

INSERT INTO "categories" ("name", "is_parent", "parent") VALUES
    ('MEN',	'1',	NULL);