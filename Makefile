
run: #make run
	@echo "$(CYAN_COLOR)==> Run ...$(NO_COLOR)"
	@docker-compose up --build

add-migration-to-users: #make add-migration-to-users name=Initial
	@echo "$(CYAN_COLOR)==> Adding migration to users...$(NO_COLOR)"
	@dotnet ef migrations add  $(name) -c "Hex.Sample.Module.User.Infrastructure.Database.UsersContext" -o "Infrastructure/Database/Migrations" -p "./src/Hex.Sample.Module.User" -s "./src/Hex.Sample.Host"

integration-tests-users: #make unit-tests-users
	@echo "$(CYAN_COLOR)==> Testing unit tests of users...$(NO_COLOR)"
	@docker-compose -f docker-compose.tests.yml build integration-tests && docker-compose -f docker-compose.tests.yml run integration-tests