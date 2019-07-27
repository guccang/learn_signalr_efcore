pipeline {
  agent any
  stages {
    stage('docker build') {
      steps {
        echo 'echo docker build'
        bat 'echo "build" &&dotnet publish -c Debug -o ./bin/Debug'
      }
    }
    stage('test') {
      steps {
        bat 'echo "run server"  && cd "asp_signalR_efcore\\bin\\Debug" && start /b dotnet asp_signalR_efcore.dll  > server.log'
        sleep 3
        bat 'echo "run client" && cd "signalR_client\\bin\\Debug"  &&  start /b dotnet signalR_client.dll  > client.log '
        input 'check result'
      }
    }
    stage('deploy') {
      steps {
        archiveArtifacts(artifacts: '**/bin/Debug/*.*', onlyIfSuccessful: true)
        echo 'echo "deploy"'
      }
    }
  }
}