const arr = [
	[5, 3, 4, 6, 7, 8, 9, 1, 2],
	[6, 7, 2, 1, 9, 5, 3, 4, 8],
	[1, 9, 8, 3, 4, 2, 5, 6, 7],
	[8, 5, 9, 7, 6, 1, 4, 2, 3],
	[4, 2, 6, 8, 5, 3, 7, 9, 1],
	[7, 1, 3, 9, 2, 4, 8, 5, 6],
	[9, 6, 1, 5, 3, 7, 2, 8, 4],
	[2, 8, 7, 4, 1, 9, 6, 3, 5],
	[3, 4, 5, 2, 8, 6, 1, 7, 9],
];

const arr2 = [
	[5, 3, 4, 6, 7, 8, 9, 1, 2],
	[6, 7, 2, 1, 9, 0, 3, 4, 8],
	[1, 0, 0, 3, 4, 2, 5, 6, 0],
	[8, 5, 9, 7, 6, 1, 0, 2, 0],
	[4, 2, 6, 8, 5, 3, 7, 9, 1],
	[7, 1, 3, 9, 2, 4, 8, 5, 6],
	[9, 0, 1, 5, 3, 7, 2, 1, 4],
	[2, 8, 7, 4, 1, 9, 6, 3, 5],
	[3, 0, 0, 4, 8, 1, 1, 7, 9],
];

const result = validSolution(arr);
const result2 = validSolution(arr2);

document.querySelector(".result").innerHTML = "Result 1: " + result;
document.querySelector(".result2").innerHTML = "Result 2: " + result2;
console.log(result);
console.log(result2);

function validSolution(array) {
	const vertical = checkVertical(array);
	const horizontal = checkHorizontal(array);
	const blocks = checkBlocks(array);

	return vertical && horizontal && blocks;
}

function checkExistNumbersFrom1to9(array) {
	return (
		array.includes(1) &&
		array.includes(2) &&
		array.includes(3) &&
		array.includes(4) &&
		array.includes(5) &&
		array.includes(6) &&
		array.includes(7) &&
		array.includes(8) &&
		array.includes(9)
	);
}

function checkVertical(arr) {
	const array = new Array(arr.length);
	for (let i = 0; i < arr.length; i++) {
		for (let j = 0; j < arr[0].length; j++) {
			array[j] = arr[j][i];
		}
		if (array.includes(0) || !checkExistNumbersFrom1to9(array)) {
			return false;
		}
	}

	return true;
}

function checkHorizontal(arr) {
	const array = new Array(arr.length);

	for (let i = 0; i < arr.length; i++) {
		for (let j = 0; j < arr[i].length; j++) {
			array[j] = arr[i][j];
		}
		if (array.includes(0) || !checkExistNumbersFrom1to9(array)) {
			return false;
		}
	}

	return true;
}

function checkBlocks(arr) {
	const array = fillArray(arr);
	let m;
	const newArray = new Array(arr.length);

	for (let i = 0; i < array.length; i++) {
		m = 0;

		for (let j = 0; j < array[i].length; j++) {
			for (let k = 0; k < array[i][j].length; k++) {
				newArray[m] = array[i][j][k];
				m++;
			}
		}
		if (newArray.includes(0) || !checkExistNumbersFrom1to9(newArray)) {
			return false;
		}
	}
	return true;
}

function fillArray(arr) {
	const array = new Array(9);
	let n = 0,
		m = 0,
		h = 0,
		l = 0;

	for (let i = 0; i < array.length; i++) {
		array[i] = new Array(3);

		for (m = 0; m < 3; m++) {
			array[i][m] = new Array(3);

			for (h = 0; h < 3; h++) {
				array[i][m][h] = arr[m + n][h + l];
			}
		}

		if (n + 3 === 9) l += 3;

		n = n + 3 === 9 ? 0 : n + 3;
	}
	return array;
}
