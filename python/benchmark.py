import sys
import re
import json
from timeit import default_timer as timer

if len(sys.argv) != 2:
    print('Usage: python benchmark.py <filename>')
    sys.exit(1)

def measure(data, pattern):
    start_time = timer()

    regex = re.compile(pattern)
    matches = re.findall(regex, data)

    elapsed_time = timer() - start_time

    print(str(elapsed_time * 1e3) + ' - ' + str(len(matches)))

with open(sys.argv[1]) as file:
    data = file.read()
    test_regexes = json.loads(sys.argv[2])

    for regex in test_regexes:
        measure(data, regex)

