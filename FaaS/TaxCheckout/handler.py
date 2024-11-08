# import the necessary libraries
import re
import json

# define tax data which would be stored in the database in the production environment
tax_data = [
    {
        "tax_year": 2024,
        "state_tax": 5.0,
        "country_tax": 10.0,
        "city_rate": 2.5,
        "tax_rate": 17.5,
    },
    {
        "tax_year": 2023,
        "state_tax": 4.5,
        "country_tax": 9.5,
        "city_rate": 2.0,
        "tax_rate": 16.0,
    },
    {
        "tax_year": 2022,
        "state_tax": 4.0,
        "country_tax": 9.0,
        "city_rate": 1.5,
        "tax_rate": 14.5,
    },
    {
        "tax_year": 2021,
        "state_tax": 3.5,
        "country_tax": 8.5,
        "city_rate": 1.0,
        "tax_rate": 13.0,
    },
    {
        "tax_year": 2020,
        "state_tax": 3.0,
        "country_tax": 8.0,
        "city_rate": 0.5,
        "tax_rate": 11.5,
    },
]


# function to check if the input is a four digit number
def is_four_digit_number(input_value):
    if isinstance(input_value, int):
        input_value = str(input_value)
    return bool(re.fullmatch(r"\d{4}", input_value))


# function to calculate the total price including tax
def calculate_tax_included(amount, tax_percentage):

    if not isinstance(amount, (int, float)):
        raise ValueError("The amount should be a number.")

    if not isinstance(tax_percentage, (int, float)):
        raise ValueError("The tax_percentage should be a number.")

    tax_amount = amount * (tax_percentage / 100)
    total_amount = amount + tax_amount
    return total_amount


# function to check if the input is a valid number
def is_valid_number(value):

    return isinstance(value, (int, float))


# main function
def handle(req):

    # Parse the JSON request
    try:
        req_data = json.loads(req)
        year = req_data.get("year")
        price = req_data.get("price")
    except Exception as e:
        return json.dumps({"error invalid json": f"An error occurred: {str(e)}"})

    # Check if the year is a four-digit number
    if not is_four_digit_number(year):
        return json.dumps({"error": "Please enter a valid year"})

    # Check if the price is a valid number
    if not is_valid_number(price):
        return json.dumps({"error": "Please enter a valid price"})

    # Output the tax data for the given year
    for data in tax_data:
        if data["tax_year"] == int(year):
            total_price = calculate_tax_included(price, data["tax_rate"])

            # Return the total price including tax
            return json.dumps({"total_price": total_price})

    return json.dumps({"error": "Year not found in tax data"})
