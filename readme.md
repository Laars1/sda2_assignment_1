# Installation instructions
In this document all necessary steps for an sucessful installation will be provided (Tested on Windows 11)

Note: The whole documentation of our assignment is also provided in the root directory.

# How to run the microservices
## Prerequisite
To run the three microservices Visual Studio 2022 has to be installed with the ASP.NET and web deployment workload.
![image](https://github.com/user-attachments/assets/4f1b915e-b9db-4c97-830e-840525192081)

## Running the microservices
To start one microservice the following steps have to be done:
1.	Open “.sln” file of the microservice
2.	Open package management console:
![image](https://github.com/user-attachments/assets/58f3a420-1cb4-4d16-937c-6a0e915354d5)
3.	Execute the “update-database” command in the package management console
4.	Press the empty green triangle
![image](https://github.com/user-attachments/assets/8c564437-c58a-44d9-b586-0c1bf68fc0a9)

This step must be repeated for each microservice.

Afterwards the applications should be available under following URLs:
| Microservice | URL                                       |
|--------------|-------------------------------------------|
| Masterdata   | https://localhost:5001/swagger/index.html |
| Cart         | https://localhost:5002/swagger/index.html |
| Ticketing    | https://localhost:5003/swagger/index.html |

## FaaS
To deploy the FaaS the following command has to be used when you are in the “TaxCheckout” directory:
faas-cli up -f taxcheckout.yml

Because the function is already deployed to the provided OpenFaaS Server it can be directly accessed when logging into OpenFaaS Portal and selecting “taxcheckout”.
