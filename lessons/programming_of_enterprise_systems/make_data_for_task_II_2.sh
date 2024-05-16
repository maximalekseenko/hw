DB_NAME=PoES_II

ROW_AMOUNT_PER_TABLE=50
VALUE_INTEGER_SMALL_MIN=0
VALUE_INTEGER_SMALL_MAX=10
VALUE_INTEGER_BIG_MIN=1000
VALUE_INTEGER_BIG_MAX=2000
VALUE_REAL_MIN=1000
VALUE_REAL_MAX=2000
VALUE_DATE_BACK_DAYS_MIN=0
VALUE_DATE_BACK_DAYS_MAX=2000
VALUE_DATE_FORMAT='+%Y-%m-%d'


PSQL_RUN_COMMAND="psql --quiet -d ${DB_NAME} -c"
RANDOM=$(date +%s)
GET_VALUE_TEXT(){
    echo "'text$i'"
}
GET_FOREIN_KEY_ROW(){
    echo $((${RANDOM} % (${ROW_AMOUNT_PER_TABLE} - 1) + 1))
}
GET_VALUE_INTEGER_SMALL(){
    echo $((${RANDOM} % (${VALUE_INTEGER_SMALL_MAX} - ${VALUE_INTEGER_SMALL_MIN}) + ${VALUE_INTEGER_SMALL_MIN}))
}
GET_VALUE_INTEGER_BIG(){
    echo $((${RANDOM} % (${VALUE_INTEGER_BIG_MAX} - ${VALUE_INTEGER_BIG_MIN}) + ${VALUE_INTEGER_BIG_MIN})) 
}
GET_VALUE_REAL(){
    echo $(( (${RANDOM} % (${VALUE_REAL_MAX} - ${VALUE_REAL_MIN}) + ${VALUE_REAL_MIN}) + (${RANDOM} % 1000 / 1000)))
}
GET_VALUE_DATE(){
    local _new_value_date=$(( ${RANDOM} % (${VALUE_DATE_BACK_DAYS_MAX} - ${VALUE_DATE_BACK_DAYS_MIN}) + ${VALUE_DATE_BACK_DAYS_MIN} ))
    if [[ $(uname -s) == "Darwin" ]];
    then _new_value_date=$(date -j -v-${_new_value_date}d ${VALUE_DATE_FORMAT})
    else _new_value_date=$(date --date="${_new_value_date} days ago" ${VALUE_DATE_FORMAT})
    fi
    echo "'${_new_value_date}'"
}

# recreate db
    dropdb -f ${DB_NAME} --if-exists
    createdb ${DB_NAME}

# make tablesP
    ${PSQL_RUN_COMMAND} "CREATE TABLE Type (
        TypeId SERIAL PRIMARY KEY,
        TypeName VARCHAR
    );"

    ${PSQL_RUN_COMMAND} "CREATE TABLE District (
        DistrictId SERIAL PRIMARY KEY,
        DistrictName VARCHAR
    );"

    ${PSQL_RUN_COMMAND} "CREATE TABLE BuildingMaterial (
        BuildingMaterialId SERIAL PRIMARY KEY,
        MaterialName VARCHAR
    );"

    ${PSQL_RUN_COMMAND} "CREATE TABLE RealEstateObject (
        RealEstateObjectId SERIAL PRIMARY KEY,
        DistrictId INTEGER REFERENCES District(DistrictId),
        Address VARCHAR,
        Floor INTEGER,
        Rooms INTEGER,
        TypeId INTEGER REFERENCES Type(TypeId),
        Status INTEGER,
        Price REAL,
        Description VARCHAR,
        BuildingMaterialId INTEGER REFERENCES BuildingMaterial(BuildingMaterialId),
        Area REAL,
        AnnouncementDate TIMESTAMP
    );"

    ${PSQL_RUN_COMMAND} "CREATE TABLE AssessmentCriterion (
        AssessmentCriterionId SERIAL PRIMARY KEY,
        CriterionName VARCHAR
    );"

    ${PSQL_RUN_COMMAND} "CREATE TABLE Assessment (
        AssessmentId SERIAL PRIMARY KEY,
        RealEstateObjectId INTEGER REFERENCES RealEstateObject(RealEstateObjectId),
        AssessmentDate TIMESTAMP,
        AssessmentCriterionId INTEGER REFERENCES AssessmentCriterion(AssessmentCriterionId),
        Mark INTEGER
    );"

    ${PSQL_RUN_COMMAND} "CREATE TABLE Realtor (
        RealtorId SERIAL PRIMARY KEY,
        LastName VARCHAR,
        FirstName VARCHAR,
        MiddleName VARCHAR,
        PhoneNumber VARCHAR
    );"

    ${PSQL_RUN_COMMAND} "CREATE TABLE Sale (
        SaleId SERIAL PRIMARY KEY,
        RealEstateObjectId INTEGER REFERENCES RealEstateObject(RealEstateObjectId),
        SaleDate TIMESTAMP,
        RealtorId INTEGER REFERENCES Realtor(RealtorId),
        Price REAL
    );"

# fill db

    for i in `seq 1 ${ROW_AMOUNT_PER_TABLE}`
    do
        ${PSQL_RUN_COMMAND} "INSERT INTO Type (
            TypeName
        ) VALUES (
            'text${i}'
        );"
    done

    for i in `seq 1 ${ROW_AMOUNT_PER_TABLE}`
    do
        ${PSQL_RUN_COMMAND} "INSERT INTO District (
            DistrictName
        ) VALUES (
            $(GET_VALUE_TEXT)
        );"
    done

    for i in `seq 1 ${ROW_AMOUNT_PER_TABLE}`
    do
        ${PSQL_RUN_COMMAND} "INSERT INTO BuildingMaterial (
            MaterialName
        ) VALUES (
            $(GET_VALUE_TEXT)
        );"
    done

    for i in `seq 1 ${ROW_AMOUNT_PER_TABLE}`
    do
        ${PSQL_RUN_COMMAND} "INSERT INTO RealEstateObject (
            DistrictId,
            Address,
            Floor,
            Rooms,
            TypeId,
            Status,
            Price,
            Description,
            BuildingMaterialId,
            Area,
            AnnouncementDate
        ) VALUES (
            $(GET_FOREIN_KEY_ROW),
            $(GET_VALUE_TEXT),
            $(GET_VALUE_INTEGER_SMALL),
            $(GET_VALUE_INTEGER_SMALL),
            $(GET_FOREIN_KEY_ROW),
            $((${RANDOM} % 1)),
            $(GET_VALUE_REAL),
            $(GET_VALUE_TEXT),
            $(GET_FOREIN_KEY_ROW),
            $(GET_VALUE_REAL),
            $(GET_VALUE_DATE)
        );"
    done

    for i in `seq 1 ${ROW_AMOUNT_PER_TABLE}`
    do
        ${PSQL_RUN_COMMAND} "INSERT INTO AssessmentCriterion (
            CriterionName
        ) VALUES (
            $(GET_VALUE_TEXT)
        );"
    done

    for i in `seq 1 ${ROW_AMOUNT_PER_TABLE}`
    do
        ${PSQL_RUN_COMMAND} "INSERT INTO Assessment (
            RealEstateObjectId,
            AssessmentDate,
            AssessmentCriterionId,
            Mark
        ) VALUES (
            $(GET_FOREIN_KEY_ROW),
            $(GET_VALUE_DATE),
            $(GET_FOREIN_KEY_ROW),
            $(GET_VALUE_INTEGER_SMALL)
        );"
    done

    for i in `seq 1 ${ROW_AMOUNT_PER_TABLE}`
    do
        ${PSQL_RUN_COMMAND} "INSERT INTO Realtor (
            LastName,
            FirstName,
            MiddleName,
            PhoneNumber
        ) VALUES (
            $(GET_VALUE_TEXT),
            $(GET_VALUE_TEXT),
            $(GET_VALUE_TEXT),
            $(GET_VALUE_TEXT)
        );"
    done

    for i in `seq 1 ${ROW_AMOUNT_PER_TABLE}`
    do
        ${PSQL_RUN_COMMAND} "INSERT INTO Sale (
            RealEstateObjectId,
            SaleDate,
            RealtorId,
            Price
        ) VALUES (
            $(GET_FOREIN_KEY_ROW),
            $(GET_VALUE_DATE),
            $(GET_FOREIN_KEY_ROW),
            $(GET_VALUE_REAL)
        );"
    done