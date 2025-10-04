from fastapi import FastAPI
from pydantic import BaseModel

app = FastAPI()

class InputData(BaseModel):
    numbers: list[int]
    operators: str

class OutputData(BaseModel):
    result: int

def execute(operation: str, numbers: list[int]) ->int:
    match operation:
        case '+':
            return sum(numbers)
        case '-':
            return numbers[0] - sum(numbers[1:])
        case '*':
            result = 1
            for number in numbers:
                result *= number
            return result
        case '/':
            result = numbers[0]
            for number in numbers[1:]:
                if number == 0:
                    raise ValueError("Division by zero is not allowed.")
                result /= number
            return int(result)
        case _:
            raise ValueError("Unsupported operator.")

@app.post("/execute_math", response_model=OutputData)
async def execute_math(data: InputData):
    try:
        print(data.numbers)
        print(data.operators)
        result = execute(data.operators, data.numbers)
        print(result)
        return OutputData(result=result)
    except ValueError as e:
        return {"error": str(e)}
        
            