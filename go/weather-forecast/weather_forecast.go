// Package weather provides tools to get a weather forecast.
package weather

// CurrentCondition represents the current weather condition.
var CurrentCondition string

// CurrentLocation represents the current location to retrieve the forecast for.
var CurrentLocation string

// Forecast retreives the weather forecast for the specified city and condition.
func Forecast(city, condition string) string {
	CurrentLocation, CurrentCondition = city, condition
	return CurrentLocation + " - current weather condition: " + CurrentCondition
}
