import random

TABLE_LEN = 100

RANGE_consumer_key        = [ 0,    10   ]
RANGE_birth_year          = [ 2000, 2010 ]
RANGE_residence_street    = [ 0,    10   ]
RANGE_vendor_code         = [ 0,    10  ]
RANGE_category            = [ 0,    10   ]
RANGE_discount            = [ 0,    100  ]
RANGE_manufacture_country = [ 0,    10   ]
RANGE_shop_name           = [ 0,    10   ]
RANGE_cost                = [ 1000, 5000 ]

def Get_consumer_key(): return f"\"consumer_key\":{random.randrange(*RANGE_consumer_key)}"
def Get_birth_year(): return f"\"birth_year\":{random.randrange(*RANGE_birth_year)}"
def Get_residence_street(): return f"\"residence_street\":\"Street№{random.randrange(*RANGE_residence_street)}\""
def Get_vendor_code(): return f"\"vendor_code\":{random.randrange(*RANGE_vendor_code)}"
def Get_category(): return f"\"category\":\"Category№{random.randrange(*RANGE_category)}\""
def Get_discount(): return f"\"discount\":{float(random.randrange(*RANGE_discount)) / 100}"
def Get_manufacture_country(): return f"\"manufacture_country\":\"Country№{random.randrange(*RANGE_manufacture_country)}\""
def Get_shop_name(): return f"\"shop_name\":\"Shop№{random.randrange(*RANGE_shop_name)}\""
def Get_cost(): return f"\"cost\":{random.randrange(*RANGE_cost)}"

def Make_New_For_A(): return '{' + f"{Get_consumer_key()}, {Get_birth_year()}, {Get_residence_street()}" + '}'
def Make_New_For_B(): return '{' + f"{Get_vendor_code()}, {Get_category()}, {Get_manufacture_country()}" + '}'
def Make_New_For_C(): return '{' + f"{Get_consumer_key()}, {Get_shop_name()}, {Get_discount()}" + '}'
def Make_New_For_D(): return '{' + f"{Get_vendor_code()}, {Get_shop_name()}, {Get_cost()}" + '}'
def Make_New_For_E(): return '{' + f"{Get_consumer_key()}, {Get_vendor_code()}, {Get_shop_name()}" + '}'

def Make_Table(name, func):

    with open(f"./Data/table_{name}.json", "w") as _outfile:

        new_table = []

        _outfile.write('[\n')
        while len(new_table) < TABLE_LEN:
            new_line = func()
            if new_line not in new_table:
                new_table.append(new_line)
                if len(new_table) == TABLE_LEN:
                    _outfile.write('\t'+new_line+'\n')
                else: _outfile.write('\t'+new_line+',\n')
        _outfile.write(']\n')



# ----------------------------------------
Make_Table("A", Make_New_For_A)
Make_Table("B", Make_New_For_B)
Make_Table("C", Make_New_For_C)
Make_Table("D", Make_New_For_D)
Make_Table("E", Make_New_For_E)