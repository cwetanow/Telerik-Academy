/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function findPrimes(starting, ending) {
	starting = +starting;
	ending = +ending;
	var result = [];

	if (isNaN(starting) || isNaN(ending)) {
		throw new Error();
	}

	for (var i = starting; i <= ending; i += 1) {
		if (isPrime(i)) {
			result.push(i);
		}
	}

	function isPrime(number) {
		if (number < 2) {
			return false;
		}
		for (var index = 2; index <= Math.sqrt(number); index += 1) {
			if (number % index === 0) {
				return false;
			}
		}
		return true;
	}

	return result;
}

module.exports = findPrimes;
