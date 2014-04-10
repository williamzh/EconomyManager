
// Array extensions
// ----------------------------------------

Array.prototype.aggregate = function(seed, valueCallback) {
	var value = seed;

	for(var i = 0; i < this.length; i++) {
		value += valueCallback(this[i]);
	}

	return value;
}


// Date extensions
// ----------------------------------------

Date.prototype.subtract = function(date) {
	// Calculate the difference in milliseconds
	var diff = Math.abs(this.getTime() - date.getTime());

	return new Date(diff);
}

Date.prototype.toDays = function() {
	// The number of milliseconds in one day
	var oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds

	// Convert back to days
	return Math.ceil(this.getTime() / oneDay);	
}