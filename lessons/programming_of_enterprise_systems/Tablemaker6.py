import random

TABLE_LEN = 100
TAB, SEP = '\t', '\n'

RANGE_ФИО_Ф              = [ 0,    100  ]
RANGE_ФИО_И              = [ 0,    100  ]
RANGE_ФИО_О              = [ 0,    100  ]
RANGE_Год_рождения       = [ 2024-60, 2024 ]

RANGE_Работа             = [ 1,    100  ]
RANGE_Название_должности = [ 0,    100  ]
RANGE_Make_Дата_окончания= [0, 10]
RANGE_Дата_г             = [ 2024-60, 2024 ]
RANGE_Дата_м             = [ 1,    12   ]
RANGE_Дата_д             = [ 1,    30   ]
RANGE_Отдел              = [ 0,    100  ]

RANGE_Зарплата           = [ 1,    100  ]
RANGE_Год                = RANGE_Дата_г
RANGE_Месяц              = [ 1,    12   ]
RANGE_Итого              = [ 10000, 1000000 ]

def Make_ФИО(): return f"Фамилия_{random.randrange(*RANGE_ФИО_Ф)} Имя_{random.randrange(*RANGE_ФИО_И)} Отчество_{random.randrange(*RANGE_ФИО_О)}"
def Make_Год_рождения(): return f"{random.randrange(*RANGE_Год_рождения)}"
def Make_Название_должности(): return f"Должность_{random.randrange(*RANGE_Название_должности)}"
def Make_Дата_начала(): return f"{random.randrange(*RANGE_Дата_г)}.{random.randrange(*RANGE_Дата_м)}.{random.randrange(*RANGE_Дата_д)}"
def Make_Дата_окончания(): 
    if random.randrange(*RANGE_Make_Дата_окончания):
        return f"{random.randrange(*RANGE_Дата_г)}.{random.randrange(*RANGE_Дата_м)}.{random.randrange(*RANGE_Дата_д)}"
    else: return ""
def Make_Отдел(): return f"Отдел_{random.randrange(*RANGE_Отдел)}"
def Make_Год(): return f"{random.randrange(*RANGE_Год)}"
def Make_Месяц(): return f"{random.randrange(*RANGE_Месяц)}"
def Make_Итого(): return f"{random.randrange(*RANGE_Итого)}"


def Make_Table():

    with open(f"./Data/table_6.xml", "w") as _outfile:

        new_table = []
        
        _outfile.write(f'<?xml version="1.0" encoding="utf-8"?>{SEP}')
        _outfile.write(f'<root>{SEP}')

        while len(new_table) < TABLE_LEN:
            ФИО = Make_ФИО()

            new_line =  f"{TAB}<Сотрудник>{SEP}"
            new_line += f"{TAB}{TAB}<ФИО>{ФИО}</ФИО>{SEP}"
            new_line += f"{TAB}{TAB}<Год_рождения>{Make_Год_рождения()}</Год_рождения>{SEP}"
            new_line += f"{TAB}{TAB}<Список_Работ>{SEP}"

            for _ in range(random.randrange(*RANGE_Работа)):
                new_line += f"{TAB}{TAB}{TAB}<Работа>{SEP}"
                new_line += f"{TAB}{TAB}{TAB}{TAB}<Название_должности>{Make_Название_должности()}</Название_должности>{SEP}"
                new_line += f"{TAB}{TAB}{TAB}{TAB}<Дата_начала>{Make_Дата_начала()}</Дата_начала>{SEP}"
                new_line += f"{TAB}{TAB}{TAB}{TAB}<Дата_окончания>{Make_Дата_окончания()}</Дата_окончания>{SEP}"
                new_line += f"{TAB}{TAB}{TAB}{TAB}<Отдел>{Make_Отдел()}</Отдел>{SEP}"
                new_line += f"{TAB}{TAB}{TAB}</Работа>{SEP}"
            new_line += f"{TAB}{TAB}</Список_Работ>{SEP}"
            new_line += f"{TAB}{TAB}<Список_Зарплат>{SEP}"
            for _ in range(random.randrange(*RANGE_Зарплата)):
                new_line += f"{TAB}{TAB}{TAB}<Зарплата>{SEP}"
                new_line += f"{TAB}{TAB}{TAB}{TAB}<Год>{Make_Год()}</Год>{SEP}"
                new_line += f"{TAB}{TAB}{TAB}{TAB}<Месяц>{Make_Месяц()}</Месяц>{SEP}"
                new_line += f"{TAB}{TAB}{TAB}{TAB}<Итого>{Make_Итого()}</Итого>{SEP}"
                new_line += f"{TAB}{TAB}{TAB}</Зарплата>{SEP}"
            new_line += f"{TAB}{TAB}</Список_Зарплат>{SEP}"
            new_line += f"{TAB}</Сотрудник>{SEP}"

            if ФИО.split()[0] not in new_table:
                new_table.append(ФИО.split()[0])
                _outfile.write(new_line)

        _outfile.write('</root>\n')



# ----------------------------------------
Make_Table()