# My Bus Schedule

## Assumptions
### API
1. OK to ignore time zones

### Web
1. Only interested in stops 1 and 2 
1. UI should update every minute 
1. UI and client are in the same timezone

## Notes and next steps
### API
1. Better search algorithm. Perhaps some pre-calculation.
1. Tighten CORS capabilities

### Web
1. Display does not match requirements exactly. Need to parse the data to extract the difference in minutes from the current time. Might need to change API so data can be more easily parsed. Most likely a change from `TimeSpan` to `DateTime`.
1. UI could change to use more advance aspects of Angular like directives
1. UI should handle initial button text so it doesn't flash the curly braces
1. UI might integrate a better date parsing library like momentjs
1. System might be changed to use UTC time
1. Angular unit tests not written, although not much to test that isn't framework code

