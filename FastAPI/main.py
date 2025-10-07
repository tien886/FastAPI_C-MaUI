from fastapi import FastAPI
from pydantic import BaseModel
import json, os
import base64
app = FastAPI()
# os.makedirs("JsonVault", exist_ok=True)
os.makedirs("FastAPI", exist_ok=True)   #Ensure the image storage dir exist 
#module01
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
        # id = len(os.listdir("JsonVault")) + 1
        # with open(f'JsonVault/result{id}.json', 'w') as f:
        #     json.dump({
        #         "numbers": data.numbers,
        #         "operator": data.operators,
        #         "result": result
        #         }, f, indent=4)
        return OutputData(result=result)
    except ValueError as e:
        return {"error": str(e)}

#module02
class InputImage(BaseModel):
    Base64stringFaceOfUser: str
    UserName: str
    UserId : str
class OutputImage(BaseModel):
    pass

@app.post("/execute_image", response_model=OutputImage)
async def execute_image(data: InputImage):
    decodeddata = base64.b64decode(data.Base64stringFaceOfUser)
    filepath = f"FastAPI/ImageFromC#/{data.UserId}.jpg"
    with open(filepath, "wb") as f:
        f.write(decodeddata)
    if(filepath):
        print("✅ Image saved successfully:", filepath)
    else:
        print("Fail to open file")
    return OutputImage()
      
    
