using Amazon.Lambda;

namespace Api.Builder
{
    public static class AwsBuilder
    {
        public static IAmazonLambda CreateAWSClient()
        {
            //Substituir valores pelas chaves secretas.
            return new AmazonLambdaClient("accesskeyid", "acesskey", Amazon.RegionEndpoint.SAEast1);
        }
    }
}