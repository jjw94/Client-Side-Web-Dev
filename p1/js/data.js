//My data
var obj = new Object();

obj['default'] = ['Which form factor do you want?', 'Mini-ITX', 'Macro-ATX', 'ATX'];


obj['Mini-ITX'] = ['Select the Processor...', 'Intel Ion 1.8 Gz', 'Intel Ion 2.1 Gz'];
obj['Macro-ATX'] = ['Select the Processor...', 'Intel i3 3.3 Gz', 'Intel i5 3.4 Gz'];
obj['ATX'] = ['Select the Processor...', 'AMD Athelonllx 3 3.2 Gz', 'AMD FXx8 3.6 Gz'];


obj['Intel Ion 1.8 Gz'] = ['Select your RAM...', 'Crucial 4 Gb', 'Kingston 4 Gb'];
obj['Intel Ion 2.1 Gz'] = ['Select your RAM...', 'Crucial 4 Gb', 'Kingston 4 Gb'];
obj['Intel i3 3.3 Gz'] = ['Select your RAM...', 'Crucial 6 Gb', 'Crucial 8 Gb', 'Crucial 12 Gb'];
obj['Intel i5 3.4 Gz'] = ['Select your RAM...', 'Kingston 6 Gb', 'Kingston 8 Gb'];
obj['AMD Athelonllx 3 3.2 Gz'] =  ['Select your RAM...', 'Kingston 10 Gb', 'Kingston 12 Gb', 'Kingston 16 Gb'];
obj['AMD FXx8 3.6 Gz'] = ['Select your RAM...', 'Ballistix 8 Gb', 'Ballistix 12 Gb'];


obj['Crucial 4 Gb'] = ['Select your HDD...', 'Seagate 1 Gb', 'Seagate 1.5 Gb'];
obj['Kingston 4 Gb'] = ['Select your HDD...', 'Seagate 1 Gb', 'Seagate 1.5 Gb'];
obj['Crucial 6 Gb'] = ['Select your HDD...', 'Seagate 2 Gb', 'Seagate 4 Gb', 'Seagate 8 Gb'];
obj['Crucial 8 Gb'] = ['Select your HDD...', 'Seagate 10 Gb', 'Seagate 16 Gb'];
obj['Crucial 12 Gb'] =  ['Select your HDD...', 'Seagate 32 Gb', 'Seagate 64 Gb', 'Seagate 128 Gb'];
obj['Kingston 6 Gb'] = ['Select your HDD...', 'Western-Digital 1 Gb', 'Western-Digital 1.5 Gb'];
obj['Kingston 8 Gb'] = ['Select your HDD...', 'Western-Digital 2 Gb', 'Western-Digital 4 Gb'];
obj['Kingston 10 Gb'] = ['Select your HDD...', 'Western-Digital 8 Gb', 'Western-Digital 10 Gb'];
obj['Kingston 12 Gb'] = ['Select your HDD...', 'Western-Digital 12 Gb', 'Western-Digital 16 Gb'];
obj['Kingston 16 Gb'] = ['Select your HDD...', 'Western-Digital 32 Gb', 'Western-Digital 64 Gb'];
obj['Ballistix 8 Gb'] = ['Select your HDD...', 'Samsung 1 Gb', 'Samsung 1.5 Gb'];
obj['Ballistix 12 Gb'] = ['Select your HDD...', 'Samsung 2 Gb', 'Samsung 4 Gb'];


var res = new Object();
res['Seagate 1 Gb'] = ['You have customized the Puget System S Series $535', '../media/pss.jpg'];
res['Seagate 1.5 Gb'] = ['You have customized the Puget System X Series $655', '../media/psx.jpg'];
res['Seagate 2 Gb'] = ['You have customized the Maingear System D510X $690', '../media/mdx.jpg'];
res['Seagate 4 Gb'] = ['You have customized the Maingear System D750N $730', '../media/mdn.jpg'];
res['Seagate 8 Gb'] = ['You have customized the Maingear System W630Q $780', '../media/mwq.jpg'];
res['Seagate 10 Gb'] = ['You have customized the Maingear System 190 $956', '../media/m190.jpg'];
res['Seagate 16 Gb'] = ['You have customized the Falcon-NW Tiki $945', '../media/tiki.jpg'];
res['Seagate 32 Gb'] = ['You have customized the Falcon-NW Mach V $1099', '../media/machv.jpg'];
res['Seagate 64 Gb'] = ['You have customized the Falcon-NW Talon $1189', '../media/talon.jpg'];
res['Seagate 128 Gb'] = ['You have customized the Falcon-NW FragBox $1219', '../media/fragbox.jpg'];

res['Western-Digital 1 Gb'] = ['You customized the CYBERPOWER Black Pearl $630', '../media/cpbp.jpg'];
res['Western-Digital 1.5 Gb'] = ['You customized the CYBERPOWER XTREME XT $699', '../media/cpxt.jpg'];
res['Western-Digital 2 Gb'] = ['You customized the CYBERPOWER Infinity 8000 $739', '../media/cpi8000.jpg'];
res['Western-Digital 4 Gb'] = ['You customized the CYBERPOWER Gamer Infinity 8800 Pro SE $799', '../media/cpi8800.jpg'];
res['Western-Digital 8 Gb'] = ['You customized the CYBERPOWER Gamer Scorpius 7500 $849', '../media/cps7500.jpg'];
res['Western-Digital 10 Gb'] = ['You customized the CYBERPOWER Gamer Dragon $899', '../media/cpgd.jpg'];
res['Western-Digital 12 Gb'] = ['You customized the CYBERPOWER Gamer Ultra 7500 $999', '../media/cpu7500.jpg'];
res['Western-Digital 16 Gb'] = ['You customized the CYBERPOWER Gamer Ultra 7000 Elite $1199', '../media/cpuelite.jpg'];
res['Western-Digital 32 Gb'] = ['You customized the CYBERPOWER Game Ultra Crossfirex FX $1279', '../media/cpcx.jpg'];
res['Western-Digital 64 Gb'] = ['You customized the CYBERPOWER Hadron Hydro 400 $1499', '../media/cphh.jpg'];

res['Samsung 1 Gb'] = ['You customized the XOTIC PC Small Form Factor Series $1039', '../media/xpcsff.jpg'];
res['Samsung 1.5 Gb'] = ['You customized the XOTIC PC Elite Systems Series $1069', '../media/xpcelite.jpg'];
res['Samsung 2 Gb'] = ['You customized the XOTIC PC Xtreme Systems Series $1099', '../media/xpcxtreme.jpg'];
res['Samsung 4 Gb'] = ['You customized the Velocity Micro Vector Z35 $1199', '../media/vmv.jpg'];