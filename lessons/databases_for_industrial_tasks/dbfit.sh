DB_NAME=DBfIT


PSQL_RUN_COMMAND="psql --quiet -d ${DB_NAME} -c"


# drop db if exists
dropdb -f ${DB_NAME} --if-exists

# create a new one
createdb ${DB_NAME}

# make tables
# ---------- Тип ----------
${PSQL_RUN_COMMAND} "CREATE TABLE type (
    key SERIAL PRIMARY KEY,
    name VARCHAR
);"

# ---------- Районы ----------
${PSQL_RUN_COMMAND} "CREATE TABLE district (
    key SERIAL PRIMARY KEY,
    name VARCHAR
);"

# ---------- Материалы здания ----------
${PSQL_RUN_COMMAND} "CREATE TABLE material (
    key SERIAL PRIMARY KEY,
    name VARCHAR
);"

# ---------- Объект недвижимости ----------
${PSQL_RUN_COMMAND} "CREATE TABLE building (
    key SERIAL PRIMARY KEY,
    district_key INTEGER,
    address VARCHAR,
    level INTEGER,
    rooms INTEGER,
    type INTEGER,
    status INTEGER,
    price INTEGER,
    description TEXT,
    material_key INTEGER,
    square INTEGER,
    date TIMESTAMP
);"

# ---------- Критерии оценки ----------
${PSQL_RUN_COMMAND} "CREATE TABLE criteria (
    key SERIAL PRIMARY KEY,
    name VARCHAR
);"

# ---------- Оценки ----------
${PSQL_RUN_COMMAND} "CREATE TABLE rating (
    key SERIAL PRIMARY KEY,
    building_key INTEGER,
    date TIMESTAMP,
    criteria_key INTEGER,
    mark DOUBLE PRECISION
);"

# ---------- Риэлтор ----------
${PSQL_RUN_COMMAND} "CREATE TABLE realtor (
    key SERIAL PRIMARY KEY,
    surname VARCHAR,
    name VARCHAR,
    patronymic VARCHAR,
    phone VARCHAR
);"

# ---------- Продажа ----------
${PSQL_RUN_COMMAND} "CREATE TABLE sell (
    key SERIAL PRIMARY KEY,
    building_key INTEGER,
    date TIMESTAMP,
    realtor_key INTEGER,
    cost DOUBLE PRECISION
);"

# fill table
python3 makedbdata.py ${PSQL_RUN_COMMAND}



# forien keys
${PSQL_RUN_COMMAND} "ALTER TABLE building ADD FOREIGN KEY (district_key) REFERENCES district;"
${PSQL_RUN_COMMAND} "ALTER TABLE building ADD FOREIGN KEY (material_key) REFERENCES material;"
${PSQL_RUN_COMMAND} "ALTER TABLE rating ADD FOREIGN KEY (building_key) REFERENCES building;"
${PSQL_RUN_COMMAND} "ALTER TABLE rating ADD FOREIGN KEY (criteria_key) REFERENCES criteria;"
${PSQL_RUN_COMMAND} "ALTER TABLE sell ADD FOREIGN KEY (building_key) REFERENCES building;"
${PSQL_RUN_COMMAND} "ALTER TABLE sell ADD FOREIGN KEY (realtor_key) REFERENCES realtor;"

# limit values
${PSQL_RUN_COMMAND} "ALTER TABLE building ADD CONSTRAINT building_status_check CHECK (status in (0, 1));"

# change type
${PSQL_RUN_COMMAND} "ALTER TABLE building ALTER COLUMN square TYPE REAL;"
${PSQL_RUN_COMMAND} "ALTER TABLE building ALTER COLUMN price TYPE REAL;"

# set default
${PSQL_RUN_COMMAND} "ALTER TABLE building ALTER COLUMN date SET DEFAULT NOW();"

# add colunms
${PSQL_RUN_COMMAND} "ALTER TABLE building ADD class VARCHAR CHECK (class in ('эконом', 'комфорт', 'бизнес')) DEFAULT 'эконом';"

# remove colunms
${PSQL_RUN_COMMAND} "ALTER TABLE building DROP description;"

# add tables
${PSQL_RUN_COMMAND} "CREATE TABLE room_type (
    key SERIAL PRIMARY KEY
);"
${PSQL_RUN_COMMAND} "CREATE TABLE building_structure (
    key SERIAL PRIMARY KEY,
    district_key INTEGER REFERENCES building,
    room_type_key INTEGER REFERENCES room_type,
    square INTEGER CHECK (square > 0)
);"

# В таблицу «Продажа» добавьте столбец «Комиссия риэлтору», тип – вещественный.
${PSQL_RUN_COMMAND} "ALTER TABLE sell ADD realtor_commision REAL"

# Для созданного столбца в п.8. добавьте значение по умолчанию – 10
${PSQL_RUN_COMMAND} "ALTER TABLE sell ALTER COLUMN realtor_commision SET DEFAULT 10;"

# Для столбца «Код объекта» в таблице «Продажи» добавьте ограничение уникальности
${PSQL_RUN_COMMAND} "ALTER TABLE sell ADD CONSTRAINT building_key_unique UNIQUE(building_key);"

# Настроить ссылочную целостность таким образом, чтобы при удалении риэлтора, в таблице «Продажи» столбцу «Код риэлтора» присваивалось значение «null»
${PSQL_RUN_COMMAND} "ALTER TABLE sell DROP CONSTRAINT sell_realtor_key_fkey;"
${PSQL_RUN_COMMAND} "ALTER TABLE sell ADD FOREIGN KEY (realtor_key) REFERENCES realtor ON DELETE SET NULL;"

# В таблице «Оценки» добавить ограничение столбца «Оценка»: от 0 до 10.
${PSQL_RUN_COMMAND} "ALTER TABLE rating ADD CONSTRAINT rating_mark_check CHECK (mark BETWEEN 0 AND 10);"

# Настроить ссылочную целостность таким образом, чтобы при удалении критерия оценки, в таблице «Оценки» столбцу «Код критерия» присваивалось значение по умолчанию (определить самостоятельно).
${PSQL_RUN_COMMAND} "ALTER TABLE rating DROP CONSTRAINT rating_criteria_key_fkey;"
${PSQL_RUN_COMMAND} "ALTER TABLE rating ADD FOREIGN KEY (criteria_key) REFERENCES criteria ON DELETE SET NULL;"

# Добавить ограничение уникальности на комбинацию Фамилия, Имя, Отчество в таблице «Риэлтор»
${PSQL_RUN_COMMAND} "ALTER TABLE realtor ADD CONSTRAINT realtor_surname_name_patronymic_unique UNIQUE(surname, name, patronymic);"


# print tabels
${PSQL_RUN_COMMAND} "SELECT * FROM type;"
${PSQL_RUN_COMMAND} "SELECT * FROM district;"
${PSQL_RUN_COMMAND} "SELECT * FROM material;"
${PSQL_RUN_COMMAND} "SELECT * FROM building;"
${PSQL_RUN_COMMAND} "SELECT * FROM criteria;"
${PSQL_RUN_COMMAND} "SELECT * FROM rating;"
${PSQL_RUN_COMMAND} "SELECT * FROM realtor;"
${PSQL_RUN_COMMAND} "SELECT * FROM sell;"
${PSQL_RUN_COMMAND} "SELECT * FROM room_type;"
${PSQL_RUN_COMMAND} "SELECT * FROM building_structure;"