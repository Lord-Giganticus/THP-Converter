import sys, os, argparse
parser = argparse.ArgumentParser()
parser.add_argument("-in","--infile",type=str,required=True,help="The thp file to turn into a mp4 file.")
parser.add_argument("-out","--outfile",type=str,required=True,help="The output mp4 file")
def main():
    args = parser.parse_args()
    file = args.infile
    out_file = args.outfile
    if os.path.isfile(file) == False:
        raise FileNotFoundError
    if os.path.isfile(out_file) == True:
        raise FileExistsError
    os.system('cmd /c ffmpeg -i "'+file+'" "'+out_file+'"')
    print("Complete.")
    return

if __name__ == '__main__':
    exit(main())