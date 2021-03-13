import sys, os


if len(sys.argv) < 1:
    print("There MUST be one argument!")
    exit()

file = sys.argv[1]
folder = os.path.dirname(file)
name = os.path.splitext(file)
name = name[0]
if os.path.isfile(file) == False:
    print("Argument is not a valid file.")
    exit()
else:
    if file.endswith('.thp') == False:
        print("Argument is not a thp file.")
        exit()
os.chdir(folder)

os.system('cmd /c ffmpeg -i "'+file+'" "'+name+'.mp4"')
print("Complete.")
