import random
import subprocess
import sys

PSQL_RUN_COMMAND = sys.argv[1:]


TYPE_AMOUNT = 3
DISTRICT_AMOUNT = 4
MATERIAL_AMOUNT = 2
BUILDING_AMOUNT = 30
BUILDING_LEVEL_MAX = 30
BUILDING_ROOMS_WEIGHTS = {1:4, 2:3, 3:1}
BUILDING_PRICE_RANGE = [10000, 100000]
BUILDING_SQUARE_RANGE = [20, 50]
BUILDING_DATE_YEAR_RANGE = [2001, 2010]
DATE_MONTH_RANGE = [1, 12]
DATE_DAY_RANGE = [1, 28]
DATE_HOUR_RANGE = [0, 23]
DATE_MIN_RANGE = [0, 59]
DATE_SEC_RANGE = [0, 59]
CRITERIA_AMOUNT = 5
RATING_AMOUNT = 50
RATING_DATE_YEAR_RANGE = [2021, 2030]
RATING_MARK_RANGE = [0, 10]
REALTOR_AMOUNT = 5
REALTOR_NAME_RANGE = [0,3]
REALTOR_PHONE_RANGE = [70000000000, 79999999999]
SELL_AMOUNT = 20
SELL_DATE_YEAR_RANGE = [2011, 2020]
SELL_COST_RANGE = [50000, 150000]



def call(__req:str):
    subprocess.call([*PSQL_RUN_COMMAND, __req])



# ---------- type ----------
for _i in range(TYPE_AMOUNT):
    _hash_type_command = (
        "INSERT INTO type (name) VALUES ("
            # name VARCHAR
            + f"'type№{_i + 1}'"
        + ");"
    )
    call(_hash_type_command)

# ---------- district ----------
for _i in range(DISTRICT_AMOUNT):
    _hash_district_command = (
        "INSERT INTO district (name) VALUES ("
            # name VARCHAR
            + f"'district№{_i + 1}'"
        + ");"
    )
    call(_hash_district_command)

# ---------- material ----------
for _i in range(MATERIAL_AMOUNT):
    _hash_material_command = (
        "INSERT INTO material (name) VALUES ("
            # name VARCHAR
            + f"'district№{_i + 1}'"
        + ");"
    )
    call(_hash_material_command)

# ---------- building ----------
for _i in range(BUILDING_AMOUNT):
    _hash_building_command = (
        "INSERT INTO building (district_key, address, level, rooms, type, status, price, description, material_key, square, date) VALUES ("
            # district BIGINT
            + f"{random.randint(1, DISTRICT_AMOUNT)}"
            # address VARCHAR
            + f", 'address№{_i + 1}'"
            # level BIGINT
            + f", {random.randint(0, BUILDING_LEVEL_MAX-1)}"
            # rooms BIGINT
            + f", {random.choices(list(BUILDING_ROOMS_WEIGHTS.keys()), list(BUILDING_ROOMS_WEIGHTS.values()))[0]}"
            # type BIGINT
            + f", {random.randint(1, TYPE_AMOUNT)}"
            # status BIGINT
            + f", {random.randint(0, 1)}"
            # price BIGINT
            + f", {random.randint(*BUILDING_PRICE_RANGE)}"
            # description TEXT
            + f", 'description№{_i + 1}'"
            # material BIGINT
            + f", {random.randint(1, MATERIAL_AMOUNT)}"
            # square BIGINT
            + f", {random.randint(*BUILDING_SQUARE_RANGE)}"
            # date TIMESTAMP
            + f", '{
                random.randint(*BUILDING_DATE_YEAR_RANGE)
            }-{
                random.randint(*DATE_MONTH_RANGE)
            }-{
                random.randint(*DATE_DAY_RANGE)
            } {
                random.randint(*DATE_HOUR_RANGE)
            }:{
                random.randint(*DATE_MIN_RANGE)
            }:{
                random.randint(*DATE_SEC_RANGE)
            }'"
        + ");"
    )
    call(_hash_building_command)

# ---------- criteria ----------
for _i in range(CRITERIA_AMOUNT):
    _hash_criteria_command = (
        "INSERT INTO criteria (name) VALUES ("
            # name VARCHAR
            + f"'district№{_i + 1}'"
        + ");"
    )
    call(_hash_criteria_command)

# ---------- rating ----------
for _i in range(RATING_AMOUNT):
    _hash_rating_command = (
        "INSERT INTO rating (building_key, date, criteria_key, mark) VALUES ("
            # building BIGINT
            + f"{random.randint(1, DISTRICT_AMOUNT)}"
            # date TIMESTAMP
            + f", '{
                random.randint(*BUILDING_DATE_YEAR_RANGE)
            }-{
                random.randint(*DATE_MONTH_RANGE)
            }-{
                random.randint(*DATE_DAY_RANGE)
            } {
                random.randint(*DATE_HOUR_RANGE)
            }:{
                random.randint(*DATE_MIN_RANGE)
            }:{
                random.randint(*DATE_SEC_RANGE)
            }'"
            # criteria BIGINT
            + f", {random.randint(1, CRITERIA_AMOUNT)}"
            # mark DOUBLE PRECISION
            + f", {random.randint(*RATING_MARK_RANGE)}"
        + ");"
    )
    call(_hash_rating_command)

# ---------- realtor ----------
for _i in range(REALTOR_AMOUNT):
    _hash_realtor_command = (
        "INSERT INTO realtor (surname, name, patronymic, phone) VALUES ("
            # surname VARCHAR
            + f"'surname№{_i + 1}'"
            # name VARCHAR
            + f", 'name№{random.randint(*REALTOR_NAME_RANGE)}'"
            # patronymic VARCHAR
            + f", 'patronymic№{random.randint(*REALTOR_NAME_RANGE)}'"
            # phone VARCHAR
            + f", '+{random.randint(*REALTOR_PHONE_RANGE)}'"
        + ");"
    )
    call(_hash_realtor_command)

# ---------- sell ----------
_hash = [_i for _i in range(1, BUILDING_AMOUNT + 1)]
random.shuffle(_hash)

for _i in range(SELL_AMOUNT):
    _hash_sell_command = (
        "INSERT INTO sell (building_key, date, realtor_key, cost) VALUES ("
            # building BIGINT
            f"{_hash.pop()}"
            # date TIMESTAMP
            + f", '{
                random.randint(*SELL_DATE_YEAR_RANGE)
            }-{
                random.randint(*DATE_MONTH_RANGE)
            }-{
                random.randint(*DATE_DAY_RANGE)
            } {
                random.randint(*DATE_HOUR_RANGE)
            }:{
                random.randint(*DATE_MIN_RANGE)
            }:{
                random.randint(*DATE_SEC_RANGE)
            }'"
            # realtor BIGINT
            + f", {random.randint(1, REALTOR_AMOUNT)}"
            # cost DOUBLE PRECISION
            + f", {random.randint(*SELL_COST_RANGE)}"
        + ");"
    )
    call(_hash_sell_command)