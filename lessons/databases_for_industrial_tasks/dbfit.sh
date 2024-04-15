DB_NAME=DBfIT


# drop db if exists
dropdb -f ${DB_NAME} --if-exists

# create a new one
createdb ${DB_NAME}

# make tables
# ---------- Тип ----------
psql -d ${DB_NAME} -c "CREATE TABLE IF NOT EXISTS type (
    key SERIAL PRIMARY KEY,
    name VARCHAR
);"

# ---------- Районы ----------
psql -d ${DB_NAME} -c "CREATE TABLE IF NOT EXISTS districts (
    key SERIAL PRIMARY KEY,
    name VARCHAR
);"

# ---------- Материалы здания ----------
psql -d ${DB_NAME} -c "CREATE TABLE IF NOT EXISTS material (
    key SERIAL PRIMARY KEY,
    name VARCHAR
);"

# ---------- Объект недвижимости ----------
psql -d ${DB_NAME} -c "CREATE TABLE IF NOT EXISTS building (
    key SERIAL PRIMARY KEY,
    district BIGINT,
    adress VARCHAR,
    level BIGINT,
    rooms BIGINT,
    type BIGINT,
    status BIGINT,
    price BIGINT,
    descriprtion TEXT,
    material BIGINT,
    square BIGINT,
    date TIMESTAMP
);"

# ---------- Критерии оценки ----------
psql -d ${DB_NAME} -c "CREATE TABLE IF NOT EXISTS criteria (
    key SERIAL PRIMARY KEY,
    name VARCHAR
);"

# ---------- Оценки ----------
psql -d ${DB_NAME} -c "CREATE TABLE IF NOT EXISTS ratings (
    key SERIAL PRIMARY KEY,
    building BIGINT,
    date TIMESTAMP,
    criteria BIGINT,
    mark DOUBLE PRECISION
);"

# ---------- Риэлтор ----------
psql -d ${DB_NAME} -c "CREATE TABLE IF NOT EXISTS realtor (
    key SERIAL PRIMARY KEY,
    surname VARCHAR,
    patronymic VARCHAR,
    phone VARCHAR
);"

# ---------- Продажа ----------
psql -d ${DB_NAME} -c "CREATE TABLE IF NOT EXISTS sell (
    key SERIAL PRIMARY KEY,
    building BIGINT,
    date TIMESTAMP,
    realtor BIGINT,
    cost DOUBLE PRECISION
);"

# fill tables
# ---------- Тип ----------
psql -d ${DB_NAME} -c "INSERT INTO type (name) VALUES ('type№1');"
psql -d ${DB_NAME} -c "INSERT INTO type (name) VALUES ('type№2');"
psql -d ${DB_NAME} -c "INSERT INTO type (name) VALUES ('type№3');"
# ---------- Районы ----------
psql -d ${DB_NAME} -c "INSERT INTO districts (name) VALUES ('district№1');"
psql -d ${DB_NAME} -c "INSERT INTO districts (name) VALUES ('district№2');"
psql -d ${DB_NAME} -c "INSERT INTO districts (name) VALUES ('district№3');"
psql -d ${DB_NAME} -c "INSERT INTO districts (name) VALUES ('district№4');"
# ---------- Материалы здания ----------
psql -d ${DB_NAME} -c "INSERT INTO material (name) VALUES ('material№1');"
psql -d ${DB_NAME} -c "INSERT INTO material (name) VALUES ('material№2');"
# ---------- Объект недвижимости ----------
    #                                                                                                                                            district, adress,    level, rooms, type, status, price, descriprtion,  material, square, date
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 0,       'adress№1',  1,     1,     1,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 0,       'adress№2',  4,     2,     2,    1,      20000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 0,       'adress№3',  2,     3,     1,    0,      20000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 0,       'adress№4',  6,     4,     2,    1,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 0,       'adress№5',  3,     1,     2,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 0,       'adress№6',  2,     2,     2,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 0,       'adress№7',  2,     3,     1,    1,      20000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 0,       'adress№8',  7,     4,     0,    1,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 0,       'adress№9',  9,     1,     2,    1,      20000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 0,       'adress№10', 7,     2,     0,    0,      20000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 0,       'adress№11', 3,     3,     2,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 0,       'adress№12', 8,     4,     0,    1,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 0,       'adress№13', 1,     1,     1,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 1,       'adress№14', 5,     2,     2,    0,      20000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 1,       'adress№15', 2,     3,     0,    1,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 1,       'adress№16', 7,     4,     0,    0,      20000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 1,       'adress№17', 3,     5,     1,    0,      20000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 1,       'adress№18', 9,     1,     2,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 1,       'adress№19', 3,     2,     0,    1,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 1,       'adress№20', 6,     4,     1,    0,      30000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 1,       'adress№21', 2,     2,     2,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 1,       'adress№22', 6,     4,     1,    0,      30000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 1,       'adress№23', 2,     2,     0,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 1,       'adress№24', 8,     1,     1,    0,      40000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 1,       'adress№25', 6,     2,     2,    0,      40000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 1,       'adress№26', 7,     3,     1,    1,      40000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 2,       'adress№27', 4,     2,     0,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 2,       'adress№28', 1,     2,     1,    1,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 2,       'adress№29', 5,     1,     2,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 2,       'adress№30', 8,     4,     1,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 2,       'adress№31', 9,     2,     0,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 2,       'adress№32', 5,     3,     2,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 2,       'adress№33', 3,     1,     1,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 2,       'adress№34', 7,     2,     1,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 2,       'adress№35', 6,     2,     0,    1,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 2,       'adress№36', 2,     1,     1,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 2,       'adress№37', 8,     1,     2,    1,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 2,       'adress№38', 3,     4,     0,    1,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 2,       'adress№39', 8,     2,     1,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 3,       'adress№40', 3,     2,     1,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 3,       'adress№41', 5,     1,     2,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 3,       'adress№42', 7,     5,     1,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 3,       'adress№43', 8,     1,     0,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 3,       'adress№44', 1,     9,     2,    1,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 3,       'adress№45', 6,     2,     1,    1,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 3,       'adress№46', 4,     1,     2,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 3,       'adress№47', 3,     4,     0,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 3,       'adress№48', 7,     3,     1,    1,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 3,       'adress№49', 7,     2,     2,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
psql -d ${DB_NAME} -c "INSERT INTO building (district, adress, level, rooms, type, status, price, descriprtion, material, square, date) VALUES ( 3,       'adress№50', 8,     1,     0,    0,      10000, 'BlaBlaBla№1', 0,        100,    '2004-10-19 10:23:54');"
# ---------- Критерии оценки ----------
psql -d ${DB_NAME} -c "INSERT INTO criteria (name) VALUES ('type№${i}');"
# ---------- Оценки ----------
psql -d ${DB_NAME} -c "INSERT INTO ratings (name) VALUES ('type№${i}');"
# ---------- Риэлтор ----------
psql -d ${DB_NAME} -c "INSERT INTO realtor (name) VALUES ('type№${i}');"
# ---------- Продажа ----------
psql -d ${DB_NAME} -c "INSERT INTO sell (name) VALUES ('type№${i}');"

# print tabels
psql -d ${DB_NAME} -c "SELECT * FROM type;"
psql -d ${DB_NAME} -c "SELECT * FROM districts;"
psql -d ${DB_NAME} -c "SELECT * FROM material;"
psql -d ${DB_NAME} -c "SELECT * FROM building;"
psql -d ${DB_NAME} -c "SELECT * FROM criteria;"
psql -d ${DB_NAME} -c "SELECT * FROM ratings;"
psql -d ${DB_NAME} -c "SELECT * FROM realtor;"
psql -d ${DB_NAME} -c "SELECT * FROM sell;"