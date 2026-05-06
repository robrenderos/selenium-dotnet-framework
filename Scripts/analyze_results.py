import os
import json

results_path = 'bin/Debug/net10.0/allure-results'
failures = 0
passes = 0

for filename in os.listdir(results_path):
    if filename.endswith('-result.json'):
        with open(os.path.join(results_path, filename)) as f:
            data = json.load(f)
            if data.get('status') == 'failed':
                failures += 1
                print(f"FAILED: {data.get('name')} - Error: {data.get('statusDetails', {}).get('message')}")
            elif data.get('status') == 'passed':
                passes += 1

print(f"\n--- Summary ---\nPassed: {passes}\nFailed: {failures}")