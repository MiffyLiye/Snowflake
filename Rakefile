task :default => [:list]

def ensure_system_success(command)
    res = system command
    if !res
        raise
    end
end

desc 'List predefined tasks'
task :list do
    puts '== Predefined Tasks =='
    ensure_system_success 'rake --tasks'
end

desc 'Clean Build Outputs'
task :clean do
    puts '== Clean Build Outputs Started =='
    ensure_system_success "dotnet clean"
    puts '== Clean Finished =='
end

desc 'Restore packages'
task :generate do
    puts '== Restore Started =='
    ensure_system_success "dotnet restore"
    puts '== Restore Finished =='
end

desc 'Build'
task :build do
    puts '== Build Started =='
    ensure_system_success 'dotnet build'
    puts '== Build Finished =='
end

desc 'Clean and then Build'
task :rebuild => [:clean, :generate, :build] do
end

desc 'Test'
task :test do
    puts '== Test Started =='
    ensure_system_success 'dotnet test test/* --verbosity normal'
    puts '== Test Finished =='
end

desc 'Package'
task :package do
    puts '== Package Started =='
    ensure_system_success 'dotnet pack src/Snowflake/Snowflake.csproj --configuration Release --verbosity normal'
    puts '== Package Finished =='
end
