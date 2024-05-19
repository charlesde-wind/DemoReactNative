import { defineConfig } from "orval";

export default defineConfig({
  petstore: {
    input: {
      validation: true,
      target: "../Shared/swagger.json",
    },
    output: {
      target: "./src/api/generated/webapi.ts",
      mock: true,
      urlEncodeParameters: true,
      indexFiles: true,
      mode: "single",
      schemas: "./src/api/generated/models",
    },
    hooks: {
      afterAllFilesWrite: "prettier --write",
    },
  },
});
